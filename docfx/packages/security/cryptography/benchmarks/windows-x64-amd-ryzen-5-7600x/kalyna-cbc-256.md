| Description                             | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 128B         |     3.179 μs |  0.0191 μs |  0.0178 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 128B         |     7.031 μs |  0.0277 μs |  0.0246 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 128B         |     1.748 μs |  0.0071 μs |  0.0063 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 128B         |     5.006 μs |  0.0366 μs |  0.0342 μs |         - |
|                                         |              |              |            |            |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 1KB          |    19.757 μs |  0.1755 μs |  0.1556 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 1KB          |    50.707 μs |  0.3684 μs |  0.3446 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 1KB          |     9.476 μs |  0.0605 μs |  0.0566 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 1KB          |    35.897 μs |  0.2091 μs |  0.1746 μs |         - |
|                                         |              |              |            |            |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 8KB          |   151.734 μs |  0.9403 μs |  0.8796 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 8KB          |   403.922 μs |  1.7786 μs |  1.5767 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 8KB          |    71.417 μs |  0.3701 μs |  0.3281 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 8KB          |   283.202 μs |  1.7499 μs |  1.4612 μs |         - |
|                                         |              |              |            |            |           |
| Decrypt · Kalyna-256-CBC (BouncyCastle) | 128KB        | 2,414.678 μs | 20.0811 μs | 17.8013 μs |    1112 B |
| Decrypt · Kalyna-256-CBC (Managed)      | 128KB        | 6,400.867 μs | 31.7261 μs | 29.6766 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-256-CBC (BouncyCastle) | 128KB        | 1,131.781 μs |  6.8075 μs |  6.3677 μs |    1112 B |
| Encrypt · Kalyna-256-CBC (Managed)      | 128KB        | 4,633.147 μs | 21.0976 μs | 19.7347 μs |         - |