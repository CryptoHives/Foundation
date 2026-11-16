| Description                              | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 128B         |     4.938 μs | 0.0081 μs | 0.0075 μs |     310 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 128B         |     5.339 μs | 0.0056 μs | 0.0050 μs |     310 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 128B         |     4.887 μs | 0.0086 μs | 0.0081 μs |     390 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 128B         |     5.280 μs | 0.0095 μs | 0.0089 μs |     387 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 1KB          |    33.091 μs | 0.0769 μs | 0.0719 μs |     310 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 1KB          |    35.836 μs | 0.0718 μs | 0.0671 μs |     310 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 1KB          |    33.056 μs | 0.0736 μs | 0.0689 μs |     387 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 1KB          |    35.780 μs | 0.0785 μs | 0.0734 μs |     387 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 8KB          |   258.364 μs | 0.7342 μs | 0.6868 μs |     310 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 8KB          |   279.844 μs | 0.6082 μs | 0.5689 μs |     310 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 8KB          |   258.308 μs | 0.5649 μs | 0.5284 μs |     387 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 8KB          |   279.881 μs | 0.6421 μs | 0.6007 μs |     387 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 128KB        | 4,123.115 μs | 8.3132 μs | 7.7762 μs |     310 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 128KB        | 4,461.709 μs | 8.6716 μs | 8.1115 μs |     310 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 128KB        | 4,121.733 μs | 9.4201 μs | 8.8116 μs |     387 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 128KB        | 4,462.289 μs | 9.4425 μs | 8.8325 μs |     387 B |         - |