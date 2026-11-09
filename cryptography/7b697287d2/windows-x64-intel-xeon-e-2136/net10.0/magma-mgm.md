| Description                              | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|----------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 128B         |     3.794 μs |  0.0301 μs |  0.0282 μs |     310 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 128B         |     4.094 μs |  0.0602 μs |  0.0563 μs |     310 B |         - |
|                                          |              |              |            |            |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 128B         |     3.735 μs |  0.0587 μs |  0.0549 μs |     387 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 128B         |     4.046 μs |  0.0496 μs |  0.0464 μs |     387 B |         - |
|                                          |              |              |            |            |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 1KB          |    25.264 μs |  0.3711 μs |  0.3471 μs |     310 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 1KB          |    27.360 μs |  0.3866 μs |  0.3616 μs |     310 B |         - |
|                                          |              |              |            |            |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 1KB          |    25.311 μs |  0.2538 μs |  0.2374 μs |     387 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 1KB          |    27.544 μs |  0.3908 μs |  0.3656 μs |     387 B |         - |
|                                          |              |              |            |            |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 8KB          |   197.378 μs |  2.6173 μs |  2.4482 μs |     310 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 8KB          |   213.988 μs |  2.1614 μs |  2.0218 μs |     310 B |         - |
|                                          |              |              |            |            |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 8KB          |   199.138 μs |  1.6814 μs |  1.5728 μs |     387 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 8KB          |   214.669 μs |  1.4188 μs |  1.3271 μs |     387 B |         - |
|                                          |              |              |            |            |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 128KB        | 3,145.429 μs | 46.9355 μs | 43.9035 μs |     310 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 128KB        | 3,398.318 μs | 51.7250 μs | 48.3836 μs |     310 B |         - |
|                                          |              |              |            |            |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 128KB        | 3,156.431 μs | 41.8687 μs | 39.1640 μs |     387 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 128KB        | 3,409.632 μs | 38.2414 μs | 35.7710 μs |     387 B |         - |