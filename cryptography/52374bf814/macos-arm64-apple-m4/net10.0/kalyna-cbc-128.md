| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Kalyna-128-CBC (Managed)      | 128B         |     2.250 μs | 0.0008 μs | 0.0007 μs |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 128B         |     2.417 μs | 0.0038 μs | 0.0033 μs |     872 B |
|                                         |              |              |           |           |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 128B         |     1.270 μs | 0.0019 μs | 0.0018 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 128B         |     2.037 μs | 0.0020 μs | 0.0016 μs |         - |
|                                         |              |              |           |           |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 1KB          |    15.392 μs | 0.0216 μs | 0.0202 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 1KB          |    16.165 μs | 0.0157 μs | 0.0131 μs |         - |
|                                         |              |              |           |           |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 1KB          |     7.156 μs | 0.0095 μs | 0.0084 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 1KB          |    14.600 μs | 0.0194 μs | 0.0172 μs |         - |
|                                         |              |              |           |           |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 8KB          |   119.049 μs | 0.0755 μs | 0.0669 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 8KB          |   127.465 μs | 0.0254 μs | 0.0199 μs |         - |
|                                         |              |              |           |           |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 8KB          |    54.206 μs | 0.0761 μs | 0.0712 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 8KB          |   114.945 μs | 0.1831 μs | 0.1623 μs |         - |
|                                         |              |              |           |           |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 128KB        | 1,898.162 μs | 1.5546 μs | 1.4542 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 128KB        | 2,040.730 μs | 0.7159 μs | 0.5978 μs |         - |
|                                         |              |              |           |           |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 128KB        |   861.432 μs | 0.6880 μs | 0.6099 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 128KB        | 1,840.886 μs | 2.2577 μs | 2.0014 μs |         - |