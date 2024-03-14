# 配网协议

气味小播上电后，若无缓存的热点信息，则自动进入配网模式

**热点名称**：scent + mac地址，例：scentec6260b5d796

**Server 端 IP**：192.168.4.1:1133

**Server 端**：气味小播

**客户端**：车机、小播

## 配网流程

1. 客户端连接气味小播热点；
2. 客户端告知气味小播 热点账密，Mac 地址；

```json
{
  "id": 1,
  "ssid": "wifi-xxxxx",
  "password": "",
  "mac": ""
}
```

1. 气味小播告知客户端已收到热点信息

```json
{
  "id": 2,
  "information": "get_wifi_ok"
}
```

1. 客户端告知气味小播已收到告知

```json
{
  "id": 3,
  "information": "inform_ok"
}
```

1. 气味小播告知客户端开启车内热点

```json
{
  "id": 4,
  "information": "ap_on"
}
```

1. 气味小播退出配网模式，尝试连接客户端给到的热点信息 wifi-xxxxx
2. 气味小播连上车内热点

    服务端： 车机

    客户端：气味小播

3. 气味小播告知车机：wifi 连接成功

```json
{
  "id": 1,
  "information": "wifi_success"
}
```

1. 车机通知气味小播告知成功

```json
{
  "id": 2,
  "information": "infom_ok"
}
```
