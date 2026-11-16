| Description                                   | TestDataSize | Mean         | Error      | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|----------:|----------:|----------:|
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128B         |     2.721 μs |  0.0087 μs | 0.0081 μs |     306 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128B         |     3.429 μs |  0.0073 μs | 0.0061 μs |     306 B |         - |
|                                               |              |              |            |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128B         |     2.674 μs |  0.0076 μs | 0.0068 μs |     386 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128B         |     3.379 μs |  0.0055 μs | 0.0048 μs |     383 B |         - |
|                                               |              |              |            |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 1KB          |    16.937 μs |  0.0622 μs | 0.0581 μs |     306 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 1KB          |    21.272 μs |  0.0789 μs | 0.0659 μs |     306 B |         - |
|                                               |              |              |            |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 1KB          |    16.536 μs |  0.0347 μs | 0.0307 μs |     383 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 1KB          |    21.240 μs |  0.0498 μs | 0.0441 μs |     383 B |         - |
|                                               |              |              |            |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 8KB          |   127.575 μs |  0.3696 μs | 0.3276 μs |     306 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 8KB          |   163.997 μs |  0.4100 μs | 0.3835 μs |     306 B |         - |
|                                               |              |              |            |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 8KB          |   127.521 μs |  0.3149 μs | 0.2630 μs |     383 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 8KB          |   164.725 μs |  0.3863 μs | 0.3614 μs |     383 B |         - |
|                                               |              |              |            |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128KB        | 2,024.667 μs | 10.0163 μs | 9.3693 μs |     306 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128KB        | 2,604.604 μs | 10.2492 μs | 9.0856 μs |     306 B |         - |
|                                               |              |              |            |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128KB        | 2,037.676 μs |  6.2025 μs | 5.8019 μs |     383 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128KB        | 2,607.989 μs |  7.0592 μs | 6.2578 μs |     383 B |         - |