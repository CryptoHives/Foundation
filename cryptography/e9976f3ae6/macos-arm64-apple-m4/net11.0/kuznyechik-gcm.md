| Description                                     | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|------------------------------------------------ |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 128B         |       760.7 ns |      1.95 ns |      1.82 ns |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 128B         |     1,260.3 ns |      5.74 ns |      4.79 ns |         - |
|                                                 |              |                |              |              |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 128B         |       723.4 ns |      1.90 ns |      1.78 ns |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 128B         |     1,214.0 ns |     17.66 ns |     16.52 ns |         - |
|                                                 |              |                |              |              |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 1KB          |     5,076.7 ns |     17.28 ns |     16.16 ns |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 1KB          |     8,071.8 ns |     28.84 ns |     26.98 ns |         - |
|                                                 |              |                |              |              |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 1KB          |     4,982.2 ns |     15.30 ns |     14.31 ns |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 1KB          |     8,449.9 ns |     95.48 ns |     89.31 ns |         - |
|                                                 |              |                |              |              |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 8KB          |    39,075.9 ns |    115.04 ns |    107.61 ns |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 8KB          |    65,921.0 ns |    653.33 ns |    611.12 ns |         - |
|                                                 |              |                |              |              |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 8KB          |    39,122.8 ns |    137.03 ns |    128.17 ns |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 8KB          |    66,382.5 ns |    750.46 ns |    701.98 ns |         - |
|                                                 |              |                |              |              |           |
| Decrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 128KB        |   621,896.3 ns |  3,188.61 ns |  2,982.63 ns |         - |
| Decrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 128KB        | 1,038,676.3 ns |  4,855.06 ns |  4,541.42 ns |         - |
|                                                 |              |                |              |              |           |
| Encrypt · Kuznyechik-GCM (CryptoHives-ArmPmull) | 128KB        |   623,616.1 ns |  1,503.93 ns |  1,406.78 ns |         - |
| Encrypt · Kuznyechik-GCM (CryptoHives-Scalar)   | 128KB        | 1,065,091.6 ns | 12,028.61 ns | 11,251.56 ns |         - |