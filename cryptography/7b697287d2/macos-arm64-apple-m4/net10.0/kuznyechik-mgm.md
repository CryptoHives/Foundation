| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 128B         |     1.555 μs | 0.0007 μs | 0.0006 μs |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 128B         |     1.733 μs | 0.0021 μs | 0.0020 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 128B         |     1.516 μs | 0.0006 μs | 0.0006 μs |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 128B         |     1.691 μs | 0.0037 μs | 0.0034 μs |         - |
|                                                 |              |              |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 1KB          |     9.400 μs | 0.0033 μs | 0.0030 μs |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 1KB          |    10.583 μs | 0.0150 μs | 0.0140 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 1KB          |     9.360 μs | 0.0047 μs | 0.0044 μs |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 1KB          |    10.557 μs | 0.0288 μs | 0.0255 μs |         - |
|                                                 |              |              |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 8KB          |    72.172 μs | 0.0330 μs | 0.0293 μs |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 8KB          |    81.558 μs | 0.1858 μs | 0.1738 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 8KB          |    72.145 μs | 0.0234 μs | 0.0219 μs |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 8KB          |    81.578 μs | 0.1867 μs | 0.1747 μs |         - |
|                                                 |              |              |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 128KB        | 1,148.517 μs | 0.3533 μs | 0.3305 μs |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 128KB        | 1,299.077 μs | 2.4211 μs | 2.2647 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 128KB        | 1,148.619 μs | 0.4887 μs | 0.4332 μs |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 128KB        | 1,300.421 μs | 2.5375 μs | 2.3736 μs |         - |