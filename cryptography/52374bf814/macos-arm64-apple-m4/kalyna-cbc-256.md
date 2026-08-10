| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Kalyna-256-CBC (Managed)      | 128B         |     3.098 μs | 0.0014 μs | 0.0012 μs |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 128B         |     3.292 μs | 0.0033 μs | 0.0031 μs |    1112 B |
|                                         |              |              |           |           |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 128B         |     1.706 μs | 0.0020 μs | 0.0018 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 128B         |     2.787 μs | 0.0021 μs | 0.0016 μs |         - |
|                                         |              |              |           |           |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 1KB          |    21.163 μs | 0.0130 μs | 0.0115 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 1KB          |    22.254 μs | 0.0094 μs | 0.0079 μs |         - |
|                                         |              |              |           |           |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 1KB          |     9.790 μs | 0.0135 μs | 0.0126 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 1KB          |    20.026 μs | 0.0286 μs | 0.0267 μs |         - |
|                                         |              |              |           |           |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 8KB          |   163.975 μs | 0.0928 μs | 0.0775 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 8KB          |   175.451 μs | 0.0991 μs | 0.0828 μs |         - |
|                                         |              |              |           |           |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 8KB          |    74.237 μs | 0.1661 μs | 0.1473 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 8KB          |   156.759 μs | 0.1026 μs | 0.0909 μs |         - |
|                                         |              |              |           |           |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 128KB        | 2,612.778 μs | 2.0607 μs | 1.8268 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 128KB        | 2,807.778 μs | 1.5034 μs | 1.2554 μs |         - |
|                                         |              |              |           |           |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 128KB        | 1,177.886 μs | 1.7797 μs | 1.4862 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 128KB        | 2,522.515 μs | 2.0303 μs | 1.6954 μs |         - |