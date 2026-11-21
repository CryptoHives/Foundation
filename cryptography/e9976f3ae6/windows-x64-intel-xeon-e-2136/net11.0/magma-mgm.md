| Description                              | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 128B         |     4.893 μs | 0.0023 μs | 0.0022 μs |     310 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 128B         |     5.298 μs | 0.0052 μs | 0.0046 μs |     310 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 128B         |     4.839 μs | 0.0008 μs | 0.0007 μs |     390 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 128B         |     5.236 μs | 0.0026 μs | 0.0025 μs |     390 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 1KB          |    32.762 μs | 0.0085 μs | 0.0075 μs |     310 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 1KB          |    35.634 μs | 0.0115 μs | 0.0096 μs |     310 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 1KB          |    32.677 μs | 0.0066 μs | 0.0062 μs |     390 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 1KB          |    35.442 μs | 0.0076 μs | 0.0068 μs |     390 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 8KB          |   255.224 μs | 0.1130 μs | 0.0882 μs |     310 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 8KB          |   277.096 μs | 0.0355 μs | 0.0315 μs |     310 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 8KB          |   255.733 μs | 0.1202 μs | 0.1004 μs |     390 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 8KB          |   277.480 μs | 0.0437 μs | 0.0365 μs |     390 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 128KB        | 4,079.711 μs | 0.6030 μs | 0.5641 μs |     310 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 128KB        | 4,419.577 μs | 0.3661 μs | 0.3057 μs |     310 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 128KB        | 4,080.766 μs | 2.0545 μs | 1.8213 μs |     387 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 128KB        | 4,422.081 μs | 1.1887 μs | 1.1119 μs |     387 B |         - |