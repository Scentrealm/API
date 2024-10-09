## Demo 签名校验

```javascript
    import axios from 'axios';
    import crypto from 'crypto-js';

    const accessId = '$accessid';
    const accessSecret = '$accessSecret';
    const accessType = 'application/json';
    const timestamp = parseInt((new Date()).getTime() / 1000);
    const nonce = parseInt(Math.random() * 1e8);
    const version = '1.0';

    const strResult = `accept:${accessType}*`
      + `signature-nonce:${nonce}*`
      + `signature-version:${version}*`
      + `timestamp:${timestamp}*`
      + `/api/partner/scent/list`;

    const cryptoResult = crypto.HmacSHA1(strResult, accessSecret);
    const cryptoBase64 = cryptoResult.toString(crypto.enc.Base64);
    const authorization = `qwwg ${accessId}:${cryptoBase64}`;

    // 批量获取气味列表demo。 如果需要其他功能，请将url改为对应功能的 url
    axios.post('https://xiaobo.qiweiwangguo.com/api/partner/scent/list', {
      nos: '1,2,3',
    }, {
      headers: {
        'Authorization': authorization,
        'timestamp': timestamp,
        'signature-nonce': nonce,
        'signature-version': '1.0',
        'accept': 'application/json'
      }
    });


    // 使用 AI 对话
    axios.post('https://xiaobo.qiweiwangguo.com/api/partner/device/chat', {
      nos: '123,2,3,4,5,60',
      text: '调配一个令人开心愉悦的气味',
      mac: '78:21:84:75:32:2E'
    }, {
      headers: {
        'Authorization': authorization,
        'timestamp': timestamp,
        'signature-nonce': nonce,
        'signature-version': '1.0',
        'accept': 'application/json'
      }
    });

```


C# Demo 请参考 WifiXiaoBoTest 目录下
