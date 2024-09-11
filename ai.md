# AI助手 API（试用版）

## HOST 地址

测试环境：https://ai.qiweiwangguo.com

## 请求方式

POST

## 1、通过用户对话返回气味配方信息

### url 地址

/api/conversation

### 请求参数

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| names | String | 设备的气味名 | Paris wood,桂花,CK ONE |
| scents | String | 设备胶囊名 | 木语禅香,烟雨月桂,云缕缥缈 |
| message | String | 对话文本 | 请使用两种气味，调出一个可以缓解疲劳的气味。 |
| originals | Array | 上下文使用，可为空 |  |


names，scents 使用英文逗号隔开。

### 返回示例

```json
{
  "code": 200,
  "success": true,
  "data": {
    "code": "mixedPlay([{\"channelId\": 1, \"time\": 30000}, {\"channelId\": 2, \"time\": 30000}]);",
    "description": "正在混合播放木语禅香和烟雨月桂的香氛，每种持续时间30秒。",
    "remark": "混合木语禅香和烟雨月桂的香氛，可以帮助缓解疲劳，令人感到恬静与舒心。"
  }
}
```

### code 指令说明

mixedPlay: 多路播放

singlePlay: 单路播放

music: 音乐相关

clock: 闹钟相关
