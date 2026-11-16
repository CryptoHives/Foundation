| Description                              | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 128B         |     3.158 μs | 0.0035 μs | 0.0033 μs |     306 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 128B         |     3.464 μs | 0.0032 μs | 0.0027 μs |     306 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 128B         |     3.134 μs | 0.0036 μs | 0.0034 μs |     383 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 128B         |     3.435 μs | 0.0028 μs | 0.0026 μs |     383 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 1KB          |    21.417 μs | 0.0264 μs | 0.0247 μs |     306 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 1KB          |    23.561 μs | 0.0162 μs | 0.0152 μs |     306 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 1KB          |    21.429 μs | 0.0210 μs | 0.0186 μs |     383 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 1KB          |    23.543 μs | 0.0252 μs | 0.0235 μs |     383 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 8KB          |   167.702 μs | 0.3959 μs | 0.3306 μs |     306 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 8KB          |   184.391 μs | 0.1386 μs | 0.1296 μs |     306 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 8KB          |   167.490 μs | 0.2278 μs | 0.2130 μs |     383 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 8KB          |   184.405 μs | 0.2259 μs | 0.2113 μs |     383 B |         - |
|                                          |              |              |           |           |           |           |
| Decrypt · Magma-MGM (CryptoHives-PClMul) | 128KB        | 2,669.402 μs | 2.2191 μs | 1.9672 μs |     306 B |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar) | 128KB        | 2,941.857 μs | 2.3597 μs | 2.2073 μs |     306 B |         - |
|                                          |              |              |           |           |           |           |
| Encrypt · Magma-MGM (CryptoHives-PClMul) | 128KB        | 2,670.770 μs | 3.1284 μs | 2.7733 μs |     383 B |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar) | 128KB        | 2,940.580 μs | 2.5196 μs | 2.3568 μs |     383 B |         - |