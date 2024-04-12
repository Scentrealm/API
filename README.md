# 气味王国开放平台文档

## 签名校验机制

HTTP 接口需要通过签名校验，获取 key 请联系相关商务

[签名校验机制](./signature.md)

[签名校验工具](https://scentrealm.com/api-tools?flag=test)

## API 状态码说明

[API请求的状态码列表](./code.md)

## 气味基础信息

[气味基础数据](./basic.md)

1. 气味列表
2. 气味信息（气味id、名称、颜色、寿命、气味 icon、描述 等）
3. 批量获取气味信息

## Wi-Fi 设备操控 API

[Wi-Fi设备操控API](./wifi.md)

1. 设备列表（获取指定 key 下的设备信息）
2. 设备信息
3. 设备胶囊信息
4. 单路播放气味
5. 停止播放气味
6. 设备在线状态
7. 设备实时在线状态
8. 多路播放气味
9. 单条指令执行结果查询
10. 设备日志查询
11. 通知回调
12. 设备固件列表
13. 升级设备固件

## Wi-Fi 设备配网协议

Wi-Fi 版本气味小播可以通过 TCP 协议对设备进行配网操作，让设备实现云端连接

[Wi-Fi 设备配网协议](./ap.md)

## 操作 Demo

[操作 Demo](./demo/demo.js.md)
