| Description                                | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Magma-MGM (CryptoHives-ArmPmull) | 128B         |     2.874 μs |  0.0116 μs |  0.0108 μs |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar)   | 128B         |     3.172 μs |  0.0097 μs |  0.0090 μs |         - |
|                                            |              |              |            |            |           |
| Encrypt · Magma-MGM (CryptoHives-ArmPmull) | 128B         |     2.859 μs |  0.0110 μs |  0.0097 μs |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar)   | 128B         |     3.150 μs |  0.0070 μs |  0.0059 μs |         - |
|                                            |              |              |            |            |           |
| Decrypt · Magma-MGM (CryptoHives-ArmPmull) | 1KB          |    19.364 μs |  0.0868 μs |  0.0812 μs |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar)   | 1KB          |    21.425 μs |  0.0795 μs |  0.0664 μs |         - |
|                                            |              |              |            |            |           |
| Encrypt · Magma-MGM (CryptoHives-ArmPmull) | 1KB          |    19.371 μs |  0.1242 μs |  0.1162 μs |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar)   | 1KB          |    21.470 μs |  0.0664 μs |  0.0621 μs |         - |
|                                            |              |              |            |            |           |
| Decrypt · Magma-MGM (CryptoHives-ArmPmull) | 8KB          |   151.259 μs |  0.7667 μs |  0.7172 μs |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar)   | 8KB          |   167.625 μs |  0.5497 μs |  0.5142 μs |         - |
|                                            |              |              |            |            |           |
| Encrypt · Magma-MGM (CryptoHives-ArmPmull) | 8KB          |   151.328 μs |  0.6966 μs |  0.6516 μs |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar)   | 8KB          |   167.722 μs |  0.7125 μs |  0.6664 μs |         - |
|                                            |              |              |            |            |           |
| Decrypt · Magma-MGM (CryptoHives-ArmPmull) | 128KB        | 2,415.758 μs | 12.2026 μs | 11.4144 μs |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar)   | 128KB        | 2,673.178 μs | 17.7351 μs | 15.7217 μs |         - |
|                                            |              |              |            |            |           |
| Encrypt · Magma-MGM (CryptoHives-ArmPmull) | 128KB        | 2,418.388 μs | 12.3046 μs | 11.5097 μs |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar)   | 128KB        | 2,675.969 μs | 13.5769 μs | 12.0356 μs |         - |