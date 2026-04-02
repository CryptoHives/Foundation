| Description                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SM4-CBC (Managed)      | 128B         |     1.086 μs | 0.0186 μs | 0.0174 μs |         - |
| Decrypt · SM4-CBC (BouncyCastle) | 128B         |     1.296 μs | 0.0040 μs | 0.0033 μs |      40 B |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (Managed)      | 128B         |     1.094 μs | 0.0025 μs | 0.0020 μs |         - |
| Encrypt · SM4-CBC (BouncyCastle) | 128B         |     1.318 μs | 0.0039 μs | 0.0037 μs |      40 B |
|                                  |              |              |           |           |           |
| Decrypt · SM4-CBC (Managed)      | 1KB          |     7.578 μs | 0.0115 μs | 0.0102 μs |         - |
| Decrypt · SM4-CBC (BouncyCastle) | 1KB          |     8.161 μs | 0.0359 μs | 0.0336 μs |      40 B |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (Managed)      | 1KB          |     7.818 μs | 0.0111 μs | 0.0093 μs |         - |
| Encrypt · SM4-CBC (BouncyCastle) | 1KB          |     8.300 μs | 0.0232 μs | 0.0206 μs |      40 B |
|                                  |              |              |           |           |           |
| Decrypt · SM4-CBC (Managed)      | 8KB          |    59.993 μs | 0.1543 μs | 0.1367 μs |         - |
| Decrypt · SM4-CBC (BouncyCastle) | 8KB          |    63.112 μs | 0.2370 μs | 0.2101 μs |      40 B |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (Managed)      | 8KB          |    61.726 μs | 0.2238 μs | 0.1984 μs |         - |
| Encrypt · SM4-CBC (BouncyCastle) | 8KB          |    64.366 μs | 0.2745 μs | 0.2434 μs |      40 B |
|                                  |              |              |           |           |           |
| Decrypt · SM4-CBC (Managed)      | 128KB        |   954.227 μs | 2.1403 μs | 2.0021 μs |         - |
| Decrypt · SM4-CBC (BouncyCastle) | 128KB        | 1,005.145 μs | 3.4621 μs | 3.0690 μs |      40 B |
|                                  |              |              |           |           |           |
| Encrypt · SM4-CBC (Managed)      | 128KB        |   985.653 μs | 5.0841 μs | 4.5069 μs |         - |
| Encrypt · SM4-CBC (BouncyCastle) | 128KB        | 1,022.094 μs | 1.9403 μs | 1.7200 μs |      40 B |