| Description                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SM4-CBC (Managed)      | 128B         |     1.328 μs | 0.0048 μs | 0.0045 μs |         - |
| Decrypt · SM4-CBC (BouncyCastle) | 128B         |     1.408 μs | 0.0073 μs | 0.0069 μs |      40 B |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (Managed)      | 128B         |     1.439 μs | 0.0065 μs | 0.0061 μs |         - |
| Encrypt · SM4-CBC (BouncyCastle) | 128B         |     1.483 μs | 0.0046 μs | 0.0040 μs |      40 B |
|                                  |              |              |           |           |           |
| Decrypt · SM4-CBC (BouncyCastle) | 1KB          |     8.791 μs | 0.0316 μs | 0.0296 μs |      40 B |
| Decrypt · SM4-CBC (Managed)      | 1KB          |     9.380 μs | 0.0371 μs | 0.0347 μs |         - |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (BouncyCastle) | 1KB          |     9.614 μs | 0.0263 μs | 0.0246 μs |      40 B |
| Encrypt · SM4-CBC (Managed)      | 1KB          |    10.387 μs | 0.0475 μs | 0.0444 μs |         - |
|                                  |              |              |           |           |           |
| Decrypt · SM4-CBC (BouncyCastle) | 8KB          |    67.387 μs | 0.2799 μs | 0.2618 μs |      40 B |
| Decrypt · SM4-CBC (Managed)      | 8KB          |    73.730 μs | 0.1773 μs | 0.1658 μs |         - |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (BouncyCastle) | 8KB          |    74.829 μs | 0.2542 μs | 0.2378 μs |      40 B |
| Encrypt · SM4-CBC (Managed)      | 8KB          |    82.026 μs | 0.4925 μs | 0.4606 μs |         - |
|                                  |              |              |           |           |           |
| Decrypt · SM4-CBC (BouncyCastle) | 128KB        | 1,075.324 μs | 3.7339 μs | 3.4927 μs |      40 B |
| Decrypt · SM4-CBC (Managed)      | 128KB        | 1,178.999 μs | 3.6382 μs | 3.4031 μs |         - |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (BouncyCastle) | 128KB        | 1,190.920 μs | 4.7998 μs | 4.4898 μs |      40 B |
| Encrypt · SM4-CBC (Managed)      | 128KB        | 1,312.858 μs | 6.7905 μs | 6.3518 μs |         - |