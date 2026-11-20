| Description                              | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 128B         |     3.145 μs | 0.0056 μs | 0.0052 μs |     306 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 128B         |     3.459 μs | 0.0041 μs | 0.0039 μs |     306 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 128B         |     3.113 μs | 0.0038 μs | 0.0036 μs |     386 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 128B         |     3.433 μs | 0.0056 μs | 0.0053 μs |     386 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 1KB          |    21.284 μs | 0.0274 μs | 0.0229 μs |     306 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 1KB          |    23.555 μs | 0.0443 μs | 0.0370 μs |     306 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 1KB          |    21.282 μs | 0.0456 μs | 0.0427 μs |     386 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 1KB          |    23.522 μs | 0.0321 μs | 0.0300 μs |     386 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 8KB          |   166.596 μs | 0.3217 μs | 0.3009 μs |     306 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 8KB          |   184.366 μs | 0.3504 μs | 0.3277 μs |     306 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 8KB          |   166.398 μs | 0.2087 μs | 0.1952 μs |     386 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 8KB          |   184.053 μs | 0.2859 μs | 0.2674 μs |     386 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 128KB        | 2,658.472 μs | 7.2497 μs | 6.7814 μs |     306 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 128KB        | 2,938.159 μs | 4.6434 μs | 4.3434 μs |     306 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 128KB        | 2,655.338 μs | 2.2217 μs | 1.9695 μs |     383 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 128KB        | 2,936.164 μs | 2.7057 μs | 2.5309 μs |     383 B |         - |