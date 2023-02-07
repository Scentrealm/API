# Wifi设备控制API

## 请求头

请参考签名机制文档中的公共请求头列表

## HOST 地址

https://xiaobo.qiweiwangguo.com

## 资源文件地址

无

## 请求方式

POST

## 1、设备列表

### url 地址

/api/partner/device?p=1&n=15

### 请求参数

无

### 返回数据

```json
{
    "msg": "success",
    "page": {
        "total": 68,
        "current_page": 1,
        "last_page": 3,
        "n": 10
    },
    "data": [
        {
            "mac":"78:21:84:75:32:2E"
						"name":"scent78218475322e"
						"nickname":""
						"type":"wifi"
        }
    ],
    "code": 200
}
```

## 2、设备胶囊信息

### url 地址

/api/partner/device/capsule

### 请求参数

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| mac | String | 设备MAC地址 | 78:21:84:75:32:2E |

### 返回数据

```json
{
	"msg":"success",
	"data":[
		{
			"no":254,
			"channel":1,
			"life":82340,
			"status":0
		},
		{
			"no":732,
			"channel":2,
			"life":12300,
			"status":1
		},
		...,
		{
			"no":522,
			"channel":6,
			"life":12200,
			"status":0
		}
	],
	"code":200
}
```

## 3、播放气味

### url 地址

/api/partner/device/play

### 请求参数

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| mac | String | 设备MAC地址 | 78:21:84:75:32:2E |
| channel | int | 气路数，值1~6 | 1 |
| times | int | 播放时长（秒），0-一直播放 | 10 |

### 返回数据

```json
{
	"msg":"success",
	"code":200
}
```

## 4、停止播放气味

### url 地址

/api/partner/device/stop

### 请求参数

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| mac | String | 设备MAC地址 | 78:21:84:75:32:2E |
| channel | int | 气路数，值0~6，0-停止所有气路 | 1 |

返回数据

```json
{
	"msg":"success",
	"code":200
}
```

## 5、设备在线状态

### url 地址

/api/partner/device/status

### 请求参数

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| mac | String | 设备MAC地址 | 78:21:84:75:32:2E |

### 返回数据

```json
{
	"msg":"success",
	"status":"online",
	"code":200
}
```

## 6、设备在线状态（实时查询）

### url 地址

/api/partner/device/status2

### 请求参数

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| mac | String | 设备MAC地址 | 78:21:84:75:32:2E |

### 返回数据

在线时返回示例

```json
{
	"msg":200,
	"data":{
		"id":"as89d7fa980mq78gq3weqj34k5o12m0c",
		"version":"1.0",
		"time":1074307276
	},
	"code":200
}
```

离线时返回示例

```json
{
	"code":9055,
	"msg":"请求超时，设备网络不稳定或已掉线"
}
```
