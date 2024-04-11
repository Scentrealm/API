## Demo 批量获取气味数据

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

```


C# Demo 请参考 Demos 目录下
