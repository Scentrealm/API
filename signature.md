# 签名机制

所有的API接口在调用时，需要通过签名的方式进行校验

## 加密算法

签名使用的是 ****HMAC-SHA1 加密算法****

## 公共请求头

下表描述的公共请求头（Request Header）适用于通过URL发送HTTP POST请求相关API。

| 名称 | 类型 | 是否必选 | 描述 |
| --- | --- | --- | --- |
| access | String | 是 | 接受的返回结果的类型。目前只支持JSON类型，取值：application/json。 |
| timestamp | Number | 是 | 当前时间戳（秒） |
| signature-nonce | String | 是 | 签名唯一随机数。用于防止网络重放攻击，建议您每一次请求都使用不同的随机数。 |
| signature-version | String | 是 | 签名算法版本。取值：1.0。 |

## 签名流程

### 1、序列化请求头

- 将公共请求头按名称顺序正序排序
- 对每个HTTP头，按**`"HTTP头名称" + ":" + "HTTP头值" + "*"`**拼接。

### 2、序列化URI和query参数

按照**`uri + query`**方式拼接

### 3、构建完整的待签名字符串

```diff
示例
accept:application
timestamp:1661764068
signature-nonce:339497c2-d91f-4c17-a0a3-1192ee9e2202
signature-version:1.0

请求的url地址：https://xiaobo.qiweiwangguo.com/api/partner/scent?n=15&p=1

则组成的待签名字符串为：
accept:application/json*signature-nonce:339497c2-d91f-4c17-a0a3-1192ee9e2202*signature-version:1.0*timestamp:1661764068*/api/partner/scent?n=15&p=1
```

### 4、生成签名

- 对步骤3中得到的字符串，使用AccessKey Secret进行HMAC-SHA1算法加密得到bytes数组（原始二进制数据）
- 对HMAC-SHA1加密得到的bytes数组进行base64编码
- 将base64编码后的结果放到HTTP头**`Authorization`**中的**`signature`**：**`"qwwg" + " " + AccessKeyId + ":" + signature`**

> **说明** **`qwwg`**和**`AccessKeyId`**中间有空格。
>
