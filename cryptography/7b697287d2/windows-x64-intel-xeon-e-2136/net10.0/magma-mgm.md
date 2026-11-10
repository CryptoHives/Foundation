| Description                              | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 128B         |     4.948 μs | 0.0040 μs | 0.0037 μs |     310 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 128B         |     5.354 μs | 0.0050 μs | 0.0047 μs |     310 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 128B         |     4.926 μs | 0.0049 μs | 0.0045 μs |     387 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 128B         |     5.291 μs | 0.0028 μs | 0.0026 μs |     387 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 1KB          |    33.171 μs | 0.0439 μs | 0.0411 μs |     310 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 1KB          |    35.907 μs | 0.0418 μs | 0.0391 μs |     310 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 1KB          |    33.120 μs | 0.0486 μs | 0.0431 μs |     387 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 1KB          |    35.868 μs | 0.0251 μs | 0.0235 μs |     387 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 8KB          |   258.753 μs | 0.3689 μs | 0.3451 μs |     310 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 8KB          |   280.322 μs | 0.1838 μs | 0.1719 μs |     310 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 8KB          |   258.926 μs | 0.2372 μs | 0.2218 μs |     387 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 8KB          |   280.333 μs | 0.3663 μs | 0.3427 μs |     387 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 128KB        | 4,127.027 μs | 7.2229 μs | 6.7563 μs |     310 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 128KB        | 4,472.629 μs | 4.1044 μs | 3.8393 μs |     310 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 128KB        | 4,132.728 μs | 3.1479 μs | 2.9445 μs |     387 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 128KB        | 4,472.616 μs | 6.4097 μs | 5.9957 μs |     387 B |         - |