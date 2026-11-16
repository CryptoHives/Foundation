| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 128B         |     1.568 μs | 0.0012 μs | 0.0011 μs |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 128B         |     1.748 μs | 0.0034 μs | 0.0032 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 128B         |     1.528 μs | 0.0016 μs | 0.0015 μs |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 128B         |     1.705 μs | 0.0022 μs | 0.0020 μs |         - |
|                                                 |              |              |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 1KB          |     9.485 μs | 0.0082 μs | 0.0077 μs |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 1KB          |    10.689 μs | 0.0172 μs | 0.0161 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 1KB          |     9.442 μs | 0.0076 μs | 0.0071 μs |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 1KB          |    10.638 μs | 0.0201 μs | 0.0188 μs |         - |
|                                                 |              |              |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 8KB          |    72.778 μs | 0.2141 μs | 0.2002 μs |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 8KB          |    82.298 μs | 0.1164 μs | 0.1089 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 8KB          |    72.562 μs | 0.1581 μs | 0.1479 μs |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 8KB          |    82.204 μs | 0.1735 μs | 0.1623 μs |         - |
|                                                 |              |              |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 128KB        | 1,158.980 μs | 1.1101 μs | 1.0384 μs |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 128KB        | 1,309.258 μs | 2.2593 μs | 2.1134 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 128KB        | 1,155.936 μs | 0.9952 μs | 0.9309 μs |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 128KB        | 1,308.836 μs | 2.7932 μs | 2.6128 μs |         - |