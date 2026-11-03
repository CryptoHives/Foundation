| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128B         |     2.703 μs | 0.0067 μs | 0.0062 μs |     306 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128B         |     3.426 μs | 0.0052 μs | 0.0046 μs |     306 B |         - |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128B         |     2.667 μs | 0.0038 μs | 0.0032 μs |     383 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128B         |     3.358 μs | 0.0045 μs | 0.0042 μs |     383 B |         - |
|                                               |              |              |           |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 1KB          |    16.483 μs | 0.0245 μs | 0.0217 μs |     306 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 1KB          |    21.100 μs | 0.0249 μs | 0.0232 μs |     306 B |         - |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 1KB          |    16.493 μs | 0.0457 μs | 0.0405 μs |     383 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 1KB          |    21.095 μs | 0.0580 μs | 0.0543 μs |     383 B |         - |
|                                               |              |              |           |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 8KB          |   126.707 μs | 0.3142 μs | 0.2939 μs |     306 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 8KB          |   163.204 μs | 0.3570 μs | 0.3340 μs |     306 B |         - |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 8KB          |   126.818 μs | 0.2095 μs | 0.1960 μs |     383 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 8KB          |   162.821 μs | 0.1832 μs | 0.1624 μs |     383 B |         - |
|                                               |              |              |           |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128KB        | 2,014.091 μs | 6.2366 μs | 5.8337 μs |     306 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128KB        | 2,595.343 μs | 5.2230 μs | 4.8856 μs |     306 B |         - |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128KB        | 2,020.021 μs | 5.8311 μs | 5.1691 μs |     383 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128KB        | 2,587.595 μs | 5.7870 μs | 5.4131 μs |     383 B |         - |