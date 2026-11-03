| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 128B         |     724.1 ns |   0.55 ns |   0.46 ns |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 128B         |   1,160.9 ns |   1.02 ns |   0.96 ns |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 128B         |     676.9 ns |   0.37 ns |   0.34 ns |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 128B         |   1,125.6 ns |   0.52 ns |   0.46 ns |         - |
|                                                 |              |              |           |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 1KB          |   4,714.9 ns |   1.29 ns |   1.14 ns |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 1KB          |   7,739.3 ns |   3.76 ns |   3.51 ns |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 1KB          |   4,676.6 ns |   2.30 ns |   2.15 ns |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 1KB          |   7,703.1 ns |   5.46 ns |   4.84 ns |         - |
|                                                 |              |              |           |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 8KB          |  36,693.8 ns |  16.59 ns |  14.70 ns |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 8KB          |  60,443.8 ns |  18.83 ns |  16.69 ns |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 8KB          |  36,381.7 ns |  12.56 ns |  11.75 ns |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 8KB          |  60,350.1 ns |  17.80 ns |  15.78 ns |         - |
|                                                 |              |              |           |           |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 128KB        | 586,013.3 ns | 259.16 ns | 242.42 ns |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 128KB        | 965,367.1 ns | 261.62 ns | 244.72 ns |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 128KB        | 581,857.0 ns | 369.93 ns | 346.03 ns |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 128KB        | 964,496.8 ns | 356.13 ns | 333.12 ns |         - |