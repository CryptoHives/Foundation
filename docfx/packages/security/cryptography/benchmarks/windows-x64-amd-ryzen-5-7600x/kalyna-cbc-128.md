| Description                             | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 128B         |     2.368 μs |  0.0129 μs |  0.0121 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 128B         |     5.098 μs |  0.0217 μs |  0.0181 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 128B         |     1.371 μs |  0.0082 μs |  0.0073 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 128B         |     3.624 μs |  0.0163 μs |  0.0152 μs |         - |
|                                         |              |              |            |            |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 1KB          |    14.382 μs |  0.0621 μs |  0.0518 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 1KB          |    36.638 μs |  0.1544 μs |  0.1369 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 1KB          |     7.090 μs |  0.0222 μs |  0.0207 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 1KB          |    25.691 μs |  0.1319 μs |  0.1169 μs |         - |
|                                         |              |              |            |            |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 8KB          |   111.129 μs |  0.5284 μs |  0.4684 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 8KB          |   288.599 μs |  1.2770 μs |  1.1320 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 8KB          |    53.344 μs |  0.2133 μs |  0.1995 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 8KB          |   202.684 μs |  1.3553 μs |  1.2677 μs |         - |
|                                         |              |              |            |            |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 128KB        | 1,760.546 μs |  8.1925 μs |  7.6632 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 128KB        | 4,618.142 μs | 28.6711 μs | 26.8189 μs |         - |
|                                         |              |              |            |            |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 128KB        |   842.159 μs |  4.6244 μs |  4.0994 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 128KB        | 3,246.469 μs | 16.8489 μs | 15.7605 μs |         - |