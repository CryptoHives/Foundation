| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 128B         |     721.0 ns |     0.58 ns |     0.55 ns |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 128B         |   1,171.8 ns |     3.61 ns |     3.38 ns |         - |
|                                                 |              |              |             |             |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 128B         |     681.9 ns |     0.67 ns |     0.63 ns |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 128B         |   1,122.8 ns |     1.14 ns |     1.01 ns |         - |
|                                                 |              |              |             |             |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 1KB          |   4,755.0 ns |    12.00 ns |    11.23 ns |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 1KB          |   7,805.7 ns |    12.95 ns |    11.48 ns |         - |
|                                                 |              |              |             |             |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 1KB          |   4,712.6 ns |     8.89 ns |     7.88 ns |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 1KB          |   7,760.1 ns |    16.56 ns |    15.49 ns |         - |
|                                                 |              |              |             |             |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 8KB          |  36,998.9 ns |    45.65 ns |    42.70 ns |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 8KB          |  60,929.3 ns |   128.22 ns |   119.94 ns |         - |
|                                                 |              |              |             |             |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 8KB          |  36,680.3 ns |    96.66 ns |    90.42 ns |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 8KB          |  60,799.2 ns |   121.47 ns |   113.62 ns |         - |
|                                                 |              |              |             |             |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 128KB        | 590,744.3 ns |   866.39 ns |   810.42 ns |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 128KB        | 972,005.6 ns | 2,116.74 ns | 1,980.00 ns |         - |
|                                                 |              |              |             |             |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 128KB        | 586,560.7 ns |   473.58 ns |   442.99 ns |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 128KB        | 973,465.5 ns |   718.43 ns |   672.02 ns |         - |