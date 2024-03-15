# Wifi设备控制 API

## 请求头

请参考签名机制文档中的公共请求头列表
[签名机制](./signature.md)

## HOST 地址

测试环境：https://txiaobo.qiweiwangguo.com
生产环境：https://xiaobo.qiweiwangguo.com

## 资源文件地址

无

## 请求方式

POST

## 1、设备列表

### url 地址

/api/partner/device?p=1&n=15

### 请求参数

无

### 返回示例

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
            "mac":"78:21:84:75:32:2E",
            "name":"scent78218475322e",
            "nickname":"",
            "type":"wifi"
        }
    ],
    "code": 200
}
```

## 2、设备信息

### url 地址

/api/partner/device/info

### 请求参数

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| mac | String | 设备MAC地址 | 78:21:84:75:32:2E |

### 返回数据

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| charging_state | int    | 充电状态        | 1 |
| version        | String | 设备版本号      | 1.0.4 |
| voltage        | float  | 剩余电压        | 3.7 |
| wifi           | String | WiFi名称        | ATPX 4869 4G |
| time           | String | 最近一次上报时间 | 2023-02-10 12:17:07 |

### 返回示例

```json
{
	"msg":"success",
	"data":{
		"charging_state": 1,
		"time": "2023-02-10 12:17:07",
		"version": "1.0.4",
		"voltage": 3.7,
		"wifi": "ATPX 4869 4G"
	},
	"code":200
}
```

## 3、设备胶囊信息

### url 地址

/api/partner/device/capsule

### 请求参数

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| mac | String | 设备MAC地址 | 78:21:84:75:32:2E |

### 返回数据

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| no      | int    | 气味编号  | 254 |
| channel | int    | 通道      | 1 |
| life    | int    | 剩余寿命  | 82340 |
| status  | int    | 工作状态：1-工作中、0-未工作  | 1 |

### 返回示例

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

[根据 no，可以批量获取气味名称等信息](https://github.com/Scentrealm/API/tree/main?tab=readme-ov-file#3%E6%B0%94%E5%91%B3%E4%BF%A1%E6%81%AF%E6%89%B9%E9%87%8F%E6%9F%A5%E8%AF%A2)

## 4、单路播放气味

### url 地址

/api/partner/device/play

### 请求参数

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| mac | String | 设备MAC地址 | 78:21:84:75:32:2E |
| channel | int | 气路数，值1~6 | 1 |
| times | int | 播放时长（秒），0-一直播放 | 10 |
| notify_url | String | 执行结果消息回调地址（部分设备版本可用） | https://xiaobo.qiweiwangguo.com/notify |

### 返回数据

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| request_id      | String    | 该请求的唯一标识符  | 67A08B93-7320-5DFB-8FC2-C9C408F351C1 |

### 返回示例

```json
{
	"msg":"success",
	"request_id": "67A08B93-7320-5DFB-8FC2-C9C408F351C1",
	"code":200
}
```

## 5、停止播放气味

### url 地址

/api/partner/device/stop

### 请求参数

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| mac | String | 设备MAC地址 | 78:21:84:75:32:2E |
| channel | int | 气路数，值0~6，0-停止所有气路 | 1 |
| notify_url | String | 执行结果消息回调地址（部分设备版本可用） | https://xiaobo.qiweiwangguo.com/notify |

### 返回数据

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| request_id      | String    | 该请求的唯一标识符  | 67A08B93-7320-5DFB-8FC2-C9C408F351C1 |

### 返回示例

```json
{
	"msg":"success",
	"request_id": "67A08B93-7320-5DFB-8FC2-C9C408F351C1",
	"code":200
}
```

## 6、设备在线状态

### url 地址

/api/partner/device/status

### 请求参数

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| mac | String | 设备MAC地址 | 78:21:84:75:32:2E |

### 返回数据

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| status      | String    | 在线状态  | online |

### 返回示例

```json
{
	"msg":"success",
	"status":"online",
	"code":200
}
```

## 7、设备在线状态（实时查询）

### url 地址

/api/partner/device/status2

### 请求参数

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| mac | String | 设备MAC地址 | 78:21:84:75:32:2E |

### 返回示例

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

## 8、多路播放气味

### url 地址

/api/partner/device/playMixed

### 请求参数

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| mac | String | 设备MAC地址 | 78:21:84:75:32:2E |
| mixed | String | 气路数从1~6的播放量，英文逗号隔开，播放量计算方式：时间（秒）* 10ml | 20,0,10,0,40,50（表示1路播放2秒，2路不播放，3路播放1秒，4路不播放，5路播放4秒，6路播放5秒） |
| notify_url | String | 执行结果消息回调地址（部分设备版本可用） | https://xiaobo.qiweiwangguo.com/notify |

### 返回数据

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| request_id      | String    | 该请求的唯一标识符  | 67A08B93-7320-5DFB-8FC2-C9C408F351C1 |

### 返回示例

```json
{
	"msg":"success",
	"request_id": "67A08B93-7320-5DFB-8FC2-C9C408F351C1",
	"code":200
}
```

## 9、单条指令执行结果查询

支持单路、多路、停止播放的指令结果查询，且只能查询最近一个月的数据

### url 地址

/api/partner/device/log

### 请求参数

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| mac | String | 设备MAC地址 | 78:21:84:75:32:2E |
| request_id | String | 该请求的唯一标识符 | 67A08B93-7320-5DFB-8FC2-C9C408F351C1 |


### 返回数据

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| mac | String | 设备MAC地址 | 78:21:84:75:32:2E |
| request_id | String | 请求执行播放 | 67A08B93-7320-5DFB-8FC2-C9C408F351C1 |
| cmd | String | 指令类型 | playScene |
| cmd_data | String | 指令内容 | {"channel":6,"times":10} |
| send_status | int | 指令下发状态：0-失败，1-成功 | 0 |
| receive_status | int | 指令接收状态：0-等待，1-成功 | 0 |
| exec_status | int | 指令执行状态：0-等待，1-成功，2-失败 | 0 |
| exec_complete_status | int | 指令执行完成状态：0-执行中，1-完成 | 0 |
| notify_status | int | 通知状态：0-未通知，2-已通知，2-通知失败 | 0 |
| notify_result | String | 回调结果 |  |

### 返回示例

```json
{
	"msg":"success",
	"data":{
		"mac":"78:21:84:75:32:2E",
		"request_id":"67A08B93-7320-5DFB-8FC2-C9C408F351C1",
		"cmd":"playScene",
		"cmd_data":"{\"channel\":6,\"times\":10}",
		"send_status":1,
		"receive_status":1,
		"exec_status":1,
		"exec_complete_status":1,
		"notify_status":1,
		"notify_result":"",
	},
	"code":200
}
```

## 10、设备日志查询

根据 mac 地址查询设备日志，且只能查询最近一个月的数据

### url 地址

/api/partner/device/logs

### 请求参数

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| mac | String | 设备MAC地址 | 78:21:84:75:32:2E |


### 返回数据

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| mac | String | 设备MAC地址 | 78:21:84:75:32:2E |
| request_id | String | 该请求的唯一标识符 | 67A08B93-7320-5DFB-8FC2-C9C408F351C1 |
| cmd | String | 指令类型 | playScene |
| cmd_data | String | 指令内容 | {"channel":6,"times":10} |
| send_status | int | 指令下发状态：0-失败，1-成功 | 0 |
| receive_status | int | 指令接收状态：0-等待，1-成功 | 0 |
| exec_status | int | 指令执行状态：0-等待，1-成功，2-失败 | 0 |
| exec_complete_status | int | 指令执行完成状态：0-执行中，1-完成 | 0 |
| notify_status | int | 通知状态：0-未通知，2-已通知，2-通知失败 | 0 |
| notify_result | String | 回调结果 |  |

### 返回示例

```json
{
	"msg":"success",
    "page": {
        "total": 68,
        "current_page": 1,
        "last_page": 3,
        "n": 10
    },
	"data":[
		{
			"mac":"78:21:84:75:32:2E",
			"request_id":"67A08B93-7320-5DFB-8FC2-C9C408F351C1",
			"cmd":"playScene",
			"cmd_data":"{\"channel\":6,\"times\":10}",
			"send_status":1,
			"receive_status":1,
			"exec_status":1,
			"exec_complete_status":1,
			"notify_status":1,
			"notify_result":"",
		},{
			"mac":"78:21:84:75:32:2E",
			"request_id":"67A08B93-7320-5DFB-8FC2-C9C408F351C1",
			"cmd":"playScene",
			"cmd_data":"{\"channel\":6,\"times\":10}",
			"send_status":1,
			"receive_status":1,
			"exec_status":1,
			"exec_complete_status":1,
			"notify_status":1,
			"notify_result":"",
		}
	],
	"code":200
}
```

## 11、通知回调

支持单路、多路、停止播放的结果，以及配网成功，断电状态的通知回调

### url 地址

notify_url

### 请求参数

POST json格式

| 参数 | 类型 | 说明 | 示例值 |
| --- | --- | --- | --- |
| mac | String | 设备MAC地址 | 78:21:84:75:32:2E |
| request_id | String | 该请求的唯一标识符（配网成功、断电状态的回调时为空） | 67A08B93-7320-5DFB-8FC2-C9C408F351C1 |
| type | String | 消息类型  | execStart、execComplete、networkConnected、powerDisconnected |
| status | int | 消息结果 | 1 |
| remark | String | 备注消息 |  |
