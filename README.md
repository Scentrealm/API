# 气味基础数据

## 请求头

请参考签名机制文档中的公共请求头列表

## HOST 地址

https://xiaobo.qiweiwangguo.com

## 资源文件地址

（访问图片、音频、视频、文件等资源）

https://res.xiaobo.qiweiwangguo.com

## 请求方式

POST

## 1、气味列表

### url 地址

/api/partner/scent?p=1&n=15

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
            "no": 1,
            "name": "柠檬草",
            "img": "/scents/ningmengcaoheshuweicao.png",
            "color": "#A9DAD7",
            "period": 73500
        },
        {
            "no": 2,
            "name": "小山坡",
            "img": "/scents/xiaoshanpo.png",
            "color": "#C2E593",
            "period": 72000
        },
        {
            "no": 3,
            "name": "柠檬",
            "img": "/scents/ningmeng.png",
            "color": "#C2E593",
            "period": 0
        }
    ],
    "code": 200
}
```

## 2、气味信息

### url 地址

/api/partner/scent/{no}

> no 为气味编号，如果no = 2，则url地址为   /api/partner/scent/2
>

### 请求参数

无

### 返回数据

```json
{
    "msg": "success",
    "data": {
        "no": 2,
        "name": "柠檬",
        "img": "/scents/ningmeng.png",
        "color": "#C2E593",
        "period": 0
    },
    "code": 200
}
```
