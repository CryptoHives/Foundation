| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128B         |     4.763 μs | 0.0026 μs | 0.0024 μs |     310 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128B         |     5.679 μs | 0.0024 μs | 0.0020 μs |     310 B |         - |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128B         |     4.616 μs | 0.0024 μs | 0.0023 μs |     390 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128B         |     6.220 μs | 0.0027 μs | 0.0022 μs |     390 B |         - |
|                                               |              |              |           |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 1KB          |    33.701 μs | 0.0157 μs | 0.0147 μs |     310 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 1KB          |    35.587 μs | 0.1744 μs | 0.1631 μs |     310 B |         - |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 1KB          |    28.206 μs | 0.0141 μs | 0.0132 μs |     390 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 1KB          |    35.197 μs | 0.3168 μs | 0.2963 μs |     390 B |         - |
|                                               |              |              |           |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 8KB          |   217.394 μs | 0.4609 μs | 0.4311 μs |     310 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 8KB          |   300.882 μs | 0.3169 μs | 0.2964 μs |     310 B |         - |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 8KB          |   217.404 μs | 0.1320 μs | 0.1171 μs |     390 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 8KB          |   260.074 μs | 0.5171 μs | 0.4837 μs |     390 B |         - |
|                                               |              |              |           |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128KB        | 3,450.260 μs | 1.2508 μs | 1.1700 μs |     310 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128KB        | 4,172.440 μs | 5.0962 μs | 4.7669 μs |     310 B |         - |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128KB        | 3,447.892 μs | 0.9824 μs | 0.8708 μs |     390 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128KB        | 4,786.250 μs | 3.4561 μs | 3.2328 μs |     390 B |         - |