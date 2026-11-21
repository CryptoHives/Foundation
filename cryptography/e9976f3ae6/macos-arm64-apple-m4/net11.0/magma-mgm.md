| Description                                | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Magma-MGM (CryptoHives-ArmPmull) | 128B         |     2.847 μs |  0.0090 μs |  0.0080 μs |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar)   | 128B         |     3.150 μs |  0.0075 μs |  0.0063 μs |         - |
|                                            |              |              |            |            |           |
| Encrypt · Magma-MGM (CryptoHives-ArmPmull) | 128B         |     2.849 μs |  0.0088 μs |  0.0083 μs |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar)   | 128B         |     3.151 μs |  0.0118 μs |  0.0111 μs |         - |
|                                            |              |              |            |            |           |
| Decrypt · Magma-MGM (CryptoHives-ArmPmull) | 1KB          |    19.161 μs |  0.0854 μs |  0.0798 μs |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar)   | 1KB          |    21.288 μs |  0.0723 μs |  0.0676 μs |         - |
|                                            |              |              |            |            |           |
| Encrypt · Magma-MGM (CryptoHives-ArmPmull) | 1KB          |    19.212 μs |  0.1052 μs |  0.0984 μs |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar)   | 1KB          |    21.359 μs |  0.0829 μs |  0.0776 μs |         - |
|                                            |              |              |            |            |           |
| Decrypt · Magma-MGM (CryptoHives-ArmPmull) | 8KB          |   149.729 μs |  0.9401 μs |  0.8794 μs |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar)   | 8KB          |   166.818 μs |  0.5516 μs |  0.4606 μs |         - |
|                                            |              |              |            |            |           |
| Encrypt · Magma-MGM (CryptoHives-ArmPmull) | 8KB          |   150.005 μs |  0.7461 μs |  0.6979 μs |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar)   | 8KB          |   166.678 μs |  0.6117 μs |  0.5721 μs |         - |
|                                            |              |              |            |            |           |
| Decrypt · Magma-MGM (CryptoHives-ArmPmull) | 128KB        | 2,395.302 μs | 13.2605 μs | 12.4039 μs |         - |
| Decrypt · Magma-MGM (CryptoHives-Scalar)   | 128KB        | 2,671.069 μs | 10.5424 μs |  9.8613 μs |         - |
|                                            |              |              |            |            |           |
| Encrypt · Magma-MGM (CryptoHives-ArmPmull) | 128KB        | 2,392.909 μs | 14.6747 μs | 13.7267 μs |         - |
| Encrypt · Magma-MGM (CryptoHives-Scalar)   | 128KB        | 2,661.669 μs |  7.5314 μs |  7.0449 μs |         - |