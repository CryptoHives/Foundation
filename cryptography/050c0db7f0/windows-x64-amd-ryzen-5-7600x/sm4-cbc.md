| Description                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SM4-CBC (Managed)      | 128B         |     1.146 μs | 0.0075 μs | 0.0070 μs |         - |
| Decrypt · SM4-CBC (BouncyCastle) | 128B         |     1.389 μs | 0.0086 μs | 0.0072 μs |      40 B |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (Managed)      | 128B         |     1.193 μs | 0.0175 μs | 0.0155 μs |         - |
| Encrypt · SM4-CBC (BouncyCastle) | 128B         |     1.414 μs | 0.0104 μs | 0.0098 μs |      40 B |
|                                  |              |              |           |           |           |
| Decrypt · SM4-CBC (Managed)      | 1KB          |     8.215 μs | 0.0622 μs | 0.0582 μs |         - |
| Decrypt · SM4-CBC (BouncyCastle) | 1KB          |     8.855 μs | 0.1030 μs | 0.0964 μs |      40 B |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (Managed)      | 1KB          |     8.487 μs | 0.0874 μs | 0.0817 μs |         - |
| Encrypt · SM4-CBC (BouncyCastle) | 1KB          |     8.963 μs | 0.0623 μs | 0.0583 μs |      40 B |
|                                  |              |              |           |           |           |
| Decrypt · SM4-CBC (Managed)      | 8KB          |    64.437 μs | 0.5847 μs | 0.5470 μs |         - |
| Decrypt · SM4-CBC (BouncyCastle) | 8KB          |    68.904 μs | 0.7151 μs | 0.6689 μs |      40 B |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (Managed)      | 8KB          |    67.052 μs | 0.5293 μs | 0.4951 μs |         - |
| Encrypt · SM4-CBC (BouncyCastle) | 8KB          |    69.439 μs | 0.5220 μs | 0.4883 μs |      40 B |
|                                  |              |              |           |           |           |
| Decrypt · SM4-CBC (Managed)      | 128KB        | 1,034.984 μs | 7.2486 μs | 6.7804 μs |         - |
| Decrypt · SM4-CBC (BouncyCastle) | 128KB        | 1,087.291 μs | 9.1024 μs | 8.5144 μs |      40 B |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (Managed)      | 128KB        | 1,065.050 μs | 8.3059 μs | 7.7694 μs |         - |
| Encrypt · SM4-CBC (BouncyCastle) | 128KB        | 1,104.398 μs | 7.6148 μs | 7.1229 μs |      40 B |