| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128B         |     2.714 μs | 0.0050 μs | 0.0044 μs |     306 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128B         |     3.433 μs | 0.0125 μs | 0.0111 μs |     306 B |         - |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128B         |     2.667 μs | 0.0140 μs | 0.0109 μs |     386 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128B         |     3.376 μs | 0.0135 μs | 0.0126 μs |     386 B |         - |
|                                               |              |              |           |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 1KB          |    16.657 μs | 0.0936 μs | 0.0830 μs |     306 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 1KB          |    21.351 μs | 0.1042 μs | 0.0923 μs |     306 B |         - |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 1KB          |    16.537 μs | 0.0828 μs | 0.0734 μs |     386 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 1KB          |    21.234 μs | 0.1090 μs | 0.0966 μs |     386 B |         - |
|                                               |              |              |           |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 8KB          |   128.996 μs | 0.6357 μs | 0.5946 μs |     306 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 8KB          |   164.199 μs | 0.3350 μs | 0.2970 μs |     306 B |         - |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 8KB          |   127.605 μs | 0.4266 μs | 0.3991 μs |     386 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 8KB          |   164.124 μs | 0.5485 μs | 0.4863 μs |     386 B |         - |
|                                               |              |              |           |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128KB        | 2,023.854 μs | 8.3649 μs | 7.4153 μs |     306 B |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128KB        | 2,600.964 μs | 5.4500 μs | 4.8312 μs |     306 B |         - |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-PClMul) | 128KB        | 2,028.110 μs | 8.5817 μs | 7.6075 μs |     386 B |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar) | 128KB        | 2,605.190 μs | 8.2609 μs | 7.3231 μs |     386 B |         - |