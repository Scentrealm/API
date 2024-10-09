# AI助手 API（试用版）

## HOST 地址

测试环境：https://txiaobo.qiweiwangguo.com

生产环境：https://xiaobo.qiweiwangguo.com

## 请求方式

POST

## 1、通过用户对话返回气味配方信息

### url 地址

/api/partner/device/chat

### Header

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| Authorization | String | 无 | qwwg nqqqnaw1mGiKodd:0doQNmL3gIbe2FoBDFUqwxBBsgE=	 |
| accept | String | 无 | application/json |
| timestamp | Number | 无 | 1728440061 |
| signature-nonce | String | 无 | 53266272 |
| signature-version | String | 无 | 1.0 |


### 请求参数

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| mac | String | 设备 mac 地址 | 78:21:84:75:32:2E	 |
| nos | String | 气味编号（英文逗号拼接） | 123,2,3,4,5,60	 |
| text | String | 对话文本 | 调配一个开心的气味 |


nos 使用英文逗号隔开。

前面方式参考 [签名校验机制](./signature.md)

### 返回示例

```json
{
  "msg": "success",
  "data": {
    "introduction": "这款气味配方以清新、甜美的香调为主，融合了绿野芬芳的清新草本气息、柠檬的酸甜果香、森林的深邃木香，以及红糖的淡淡甜香。这些香料的组合能够营造出一种愉悦、轻松的氛围，帮助提升情绪，带来开心的感觉。",
    "proportion": {
      "2": 20,
      "3": 30,
      "4": 10,
      "5": 25,
      "60": 15,
      "123": 0
    }
  },
  "code": 200
}
```
