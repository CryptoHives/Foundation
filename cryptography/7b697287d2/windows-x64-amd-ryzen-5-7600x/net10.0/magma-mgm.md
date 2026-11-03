| Description                              | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 128B         |     3.149 μs | 0.0011 μs | 0.0009 μs |     306 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 128B         |     3.451 μs | 0.0016 μs | 0.0015 μs |     306 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 128B         |     3.115 μs | 0.0018 μs | 0.0017 μs |     383 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 128B         |     3.422 μs | 0.0011 μs | 0.0009 μs |     383 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 1KB          |    21.344 μs | 0.0129 μs | 0.0120 μs |     306 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 1KB          |    23.483 μs | 0.0187 μs | 0.0166 μs |     306 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 1KB          |    21.300 μs | 0.0152 μs | 0.0142 μs |     383 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 1KB          |    23.469 μs | 0.0126 μs | 0.0105 μs |     383 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 8KB          |   166.893 μs | 0.1100 μs | 0.0919 μs |     306 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 8KB          |   183.883 μs | 0.1107 μs | 0.1035 μs |     306 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 8KB          |   166.813 μs | 0.1195 μs | 0.1118 μs |     383 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 8KB          |   183.751 μs | 0.0852 μs | 0.0797 μs |     383 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 128KB        | 2,661.176 μs | 1.8654 μs | 1.6536 μs |     306 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 128KB        | 2,933.946 μs | 1.3872 μs | 1.2297 μs |     306 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 128KB        | 2,661.154 μs | 1.7337 μs | 1.6217 μs |     383 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 128KB        | 2,931.351 μs | 1.7683 μs | 1.6540 μs |     383 B |         - |