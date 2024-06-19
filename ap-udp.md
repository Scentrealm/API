# 配网协议（UDP）

# 小程序实现AP配网

AP配网，即传统配网，Wifi设备需要连接上路由器才能上网。

通信协议：**UDP**

### 基本流程

1. 设备顶部按键连续按5次，顶部呼吸灯闪烁，进入AP配网模式
2. 打开气味小播小程序，搜索 wifi （**需要授权定位**）
3. 找到 “scent” 开头的热点 （设备约定配网名称前缀）
4. 连接热点
5. 广播 UDP 包 （例如：json，{ xxx }）
6. 客户端监听 UDP 消息，是否配网成功

### 配网协议

1. 连接上小播热点后，发送 UDP 包；

```json
{
  "cmdType": 1,
  "ssid": "wifi-name",
  "password": "password",
}
```

1. 小播收到 UDP 信息后返回，表示设备端已经收到wifi信息；

```json
{
	"cmdType": 2
}
```

1. 客户端收到小播 UDP 信息后，发送包，客户端断开热点，连接原来的wifi；

```json
{
	"cmdType": 3
}
```

### 完整示例

1. 搜索 wifi，找到 相应 的热点。

```jsx
const me = this

wx.startWifi({
  success() {
    wx.getWifiList({
      success: consoe.log
    })

    wx.onGetWifiList(wf => {
      if (wf && wf.wifiList.length) {
        me.setData({
          wifiListArray: wf.wifiList.filter(item => item.SSID.indexOf('scent') >= 0)
        })
      }
    })
  },
  fail(res) {
    console.log('fail:', res)
  }
})
```

💡  iOS 下需要跳转到 WiFi 列表，等到列表刷新出 WiFi，在微信前台的小程序才会收到 onGetWifiList 的回调，这是苹果系统的限制，无法规避。

1. 连接指定热点

```jsx
wx.startWifi({
  success: () => {
    wx.connectWifi({
      SSID: 'bemfa_7DAA10',
      password: '',
      fail: res => {
        console.log(res)
      },
      success: () => {
        wx.showToast({
          title: '连接成功！'
        })
      }
    })
  }
})
```

💡  SSID 即为热点名称，如果同时有多个设备在配网，会有多个 wifi 的情况。

1. 广播 UDP 包，监听设备返回的消息

```jsx
const udp = wx.createUDPSocket()
const port = udp.bind()

udp.send({
  address: '255.255.255.255',
  port: 8266,
  message: '{"cmdType":1,"ssid":"ScentRealm_Ting2","password":"pwd"}'
})

udp.onMessage(res => {
  console.log(res)
})
```

💡  需要指定端口，ip 设置为 255.255.255.255 表示广播， message 为json，包含wifi名称和密码。

### 设备通信约定

通信 JSON 格式：

```json
{
  "cmdType": 1,
  "ssid": "Home-WiFi",
  "password": "abcd1234"
}
```

| 字段名 | 类型 | 说明 | 示例 |
| --- | --- | --- | --- |
| cmdType | int | 小程序数据指令，默认1 | 1 |
| ssid | string | wifi 名称 | ScentRealm_1 |
| password | string | wifi 密码 | abcd123! |
