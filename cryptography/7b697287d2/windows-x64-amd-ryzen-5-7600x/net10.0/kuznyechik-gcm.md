| Description                                   | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128B         |     1.213 μs | 0.0028 μs | 0.0026 μs |     306 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128B         |     1.641 μs | 0.0022 μs | 0.0020 μs |     306 B |         - |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128B         |     1.160 μs | 0.0026 μs | 0.0024 μs |     383 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128B         |     1.597 μs | 0.0027 μs | 0.0024 μs |     383 B |         - |
|                                               |              |              |           |           |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 1KB          |     8.088 μs | 0.0211 μs | 0.0197 μs |     306 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 1KB          |    11.003 μs | 0.0210 μs | 0.0186 μs |     306 B |         - |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 1KB          |     8.077 μs | 0.0201 μs | 0.0188 μs |     383 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 1KB          |    10.992 μs | 0.0373 μs | 0.0349 μs |     383 B |         - |
|                                               |              |              |           |           |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 8KB          |    63.341 μs | 0.2328 μs | 0.2178 μs |     306 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 8KB          |    86.049 μs | 0.2110 μs | 0.1871 μs |     306 B |         - |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 8KB          |    63.428 μs | 0.2586 μs | 0.2292 μs |     383 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 8KB          |    86.165 μs | 0.2475 μs | 0.2315 μs |     383 B |         - |
|                                               |              |              |           |           |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128KB        | 1,012.563 μs | 2.4221 μs | 2.2657 μs |     306 B |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128KB        | 1,373.052 μs | 2.5561 μs | 2.2659 μs |     306 B |         - |
|                                               |              |              |           |           |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-PClMul) | 128KB        | 1,009.305 μs | 1.6391 μs | 1.3687 μs |     383 B |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar) | 128KB        | 1,391.431 μs | 2.4064 μs | 2.1332 μs |     383 B |         - |