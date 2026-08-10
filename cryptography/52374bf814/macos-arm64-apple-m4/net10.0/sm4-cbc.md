| Description                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SM4-CBC (Managed)      | 128B         |     1.329 μs | 0.0058 μs | 0.0054 μs |         - |
| Decrypt · SM4-CBC (BouncyCastle) | 128B         |     1.418 μs | 0.0106 μs | 0.0099 μs |      40 B |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (Managed)      | 128B         |     1.447 μs | 0.0049 μs | 0.0046 μs |         - |
| Encrypt · SM4-CBC (BouncyCastle) | 128B         |     1.486 μs | 0.0035 μs | 0.0031 μs |      40 B |
|                                  |              |              |           |           |           |
| Decrypt · SM4-CBC (BouncyCastle) | 1KB          |     8.802 μs | 0.0361 μs | 0.0338 μs |      40 B |
| Decrypt · SM4-CBC (Managed)      | 1KB          |     9.392 μs | 0.0300 μs | 0.0280 μs |         - |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (BouncyCastle) | 1KB          |     9.618 μs | 0.0402 μs | 0.0356 μs |      40 B |
| Encrypt · SM4-CBC (Managed)      | 1KB          |    10.431 μs | 0.0371 μs | 0.0329 μs |         - |
|                                  |              |              |           |           |           |
| Decrypt · SM4-CBC (BouncyCastle) | 8KB          |    67.695 μs | 0.2983 μs | 0.2790 μs |      40 B |
| Decrypt · SM4-CBC (Managed)      | 8KB          |    73.865 μs | 0.3488 μs | 0.3262 μs |         - |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (BouncyCastle) | 8KB          |    74.971 μs | 0.2233 μs | 0.2089 μs |      40 B |
| Encrypt · SM4-CBC (Managed)      | 8KB          |    82.340 μs | 0.4462 μs | 0.4173 μs |         - |
|                                  |              |              |           |           |           |
| Decrypt · SM4-CBC (BouncyCastle) | 128KB        | 1,078.473 μs | 6.0526 μs | 5.3655 μs |      40 B |
| Decrypt · SM4-CBC (Managed)      | 128KB        | 1,179.205 μs | 5.2554 μs | 4.9159 μs |         - |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (BouncyCastle) | 128KB        | 1,195.655 μs | 3.5399 μs | 3.1381 μs |      40 B |
| Encrypt · SM4-CBC (Managed)      | 128KB        | 1,317.563 μs | 7.5847 μs | 7.0948 μs |         - |