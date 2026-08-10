| Description                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SM4-CBC (Managed)      | 128B         |     1.064 μs | 0.0040 μs | 0.0035 μs |         - |
| Decrypt · SM4-CBC (BouncyCastle) | 128B         |     1.299 μs | 0.0033 μs | 0.0031 μs |      40 B |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (Managed)      | 128B         |     1.092 μs | 0.0026 μs | 0.0022 μs |         - |
| Encrypt · SM4-CBC (BouncyCastle) | 128B         |     1.315 μs | 0.0047 μs | 0.0042 μs |      40 B |
|                                  |              |              |           |           |           |
| Decrypt · SM4-CBC (Managed)      | 1KB          |     7.593 μs | 0.0177 μs | 0.0166 μs |         - |
| Decrypt · SM4-CBC (BouncyCastle) | 1KB          |     8.180 μs | 0.0292 μs | 0.0273 μs |      40 B |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (Managed)      | 1KB          |     7.816 μs | 0.0099 μs | 0.0083 μs |         - |
| Encrypt · SM4-CBC (BouncyCastle) | 1KB          |     8.319 μs | 0.0250 μs | 0.0234 μs |      40 B |
|                                  |              |              |           |           |           |
| Decrypt · SM4-CBC (Managed)      | 8KB          |    59.789 μs | 0.0573 μs | 0.0478 μs |         - |
| Decrypt · SM4-CBC (BouncyCastle) | 8KB          |    63.152 μs | 0.2282 μs | 0.2023 μs |      40 B |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (Managed)      | 8KB          |    62.336 μs | 0.1842 μs | 0.1538 μs |         - |
| Encrypt · SM4-CBC (BouncyCastle) | 8KB          |    64.306 μs | 0.2261 μs | 0.2115 μs |      40 B |
|                                  |              |              |           |           |           |
| Decrypt · SM4-CBC (Managed)      | 128KB        |   957.424 μs | 1.9292 μs | 1.7102 μs |         - |
| Decrypt · SM4-CBC (BouncyCastle) | 128KB        | 1,002.123 μs | 4.2769 μs | 4.0007 μs |      40 B |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (Managed)      | 128KB        |   984.851 μs | 1.5514 μs | 1.4512 μs |         - |
| Encrypt · SM4-CBC (BouncyCastle) | 128KB        | 1,025.504 μs | 2.7869 μs | 2.4705 μs |      40 B |