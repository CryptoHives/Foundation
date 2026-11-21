| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 128B         |     1.675 μs | 0.0064 μs | 0.0060 μs |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 128B         |     1.830 μs | 0.0059 μs | 0.0055 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 128B         |     1.624 μs | 0.0057 μs | 0.0053 μs |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 128B         |     1.787 μs | 0.0055 μs | 0.0051 μs |         - |
|                                                 |              |              |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 1KB          |    10.168 μs | 0.0433 μs | 0.0405 μs |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 1KB          |    11.228 μs | 0.0293 μs | 0.0274 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 1KB          |    10.120 μs | 0.0402 μs | 0.0376 μs |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 1KB          |    11.193 μs | 0.0410 μs | 0.0384 μs |         - |
|                                                 |              |              |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 8KB          |    78.367 μs | 0.1750 μs | 0.1637 μs |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 8KB          |    86.352 μs | 0.3212 μs | 0.3004 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 8KB          |    78.254 μs | 0.2804 μs | 0.2622 μs |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 8KB          |    86.583 μs | 0.1415 μs | 0.1255 μs |         - |
|                                                 |              |              |           |           |           |
| Decrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 128KB        | 1,243.686 μs | 4.5397 μs | 4.2464 μs |         - |
| Decrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 128KB        | 1,377.123 μs | 4.9625 μs | 4.6419 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Kuznyechik-MGM (CryptoHives-ArmPmull) | 128KB        | 1,243.824 μs | 4.4273 μs | 4.1413 μs |         - |
| Encrypt · Kuznyechik-MGM (CryptoHives-Scalar)   | 128KB        | 1,376.915 μs | 5.6300 μs | 5.2663 μs |         - |