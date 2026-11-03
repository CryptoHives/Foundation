| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 128B         |     618.0 ns |     5.50 ns |     5.15 ns |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 128B         |   1,077.0 ns |     7.24 ns |     6.42 ns |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)        | 128B         |   1,247.3 ns |     3.44 ns |     3.22 ns |    2992 B |
|                                                 |              |              |             |             |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 128B         |     585.9 ns |     7.82 ns |     7.31 ns |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 128B         |   1,040.1 ns |     8.60 ns |     7.62 ns |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)        | 128B         |   1,423.2 ns |     0.92 ns |     0.87 ns |    2584 B |
|                                                 |              |              |             |             |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 1KB          |   3,022.6 ns |     9.85 ns |     9.21 ns |         - |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 1KB          |   5,702.0 ns |    13.31 ns |    12.45 ns |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)        | 1KB          |   5,748.5 ns |     4.92 ns |     4.60 ns |    7416 B |
|                                                 |              |              |             |             |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 1KB          |   2,993.1 ns |    15.30 ns |    14.31 ns |         - |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 1KB          |   5,677.9 ns |    14.84 ns |    13.88 ns |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)        | 1KB          |   5,979.2 ns |     2.57 ns |     2.40 ns |    3352 B |
|                                                 |              |              |             |             |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 8KB          |  22,225.4 ns |    86.72 ns |    81.12 ns |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)        | 8KB          |  40,669.5 ns |    48.52 ns |    43.01 ns |   43328 B |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 8KB          |  42,578.1 ns |   128.27 ns |   119.99 ns |         - |
|                                                 |              |              |             |             |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 8KB          |  22,244.3 ns |    41.32 ns |    36.63 ns |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)        | 8KB          |  42,105.3 ns |    23.71 ns |    22.18 ns |   10520 B |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 8KB          |  42,725.2 ns |   129.46 ns |   121.10 ns |         - |
|                                                 |              |              |             |             |           |
| Decrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 128KB        | 351,986.6 ns | 1,267.49 ns | 1,185.61 ns |         - |
| Decrypt · AES-128-GCM-SIV (BouncyCastle)        | 128KB        | 662,667.9 ns | 1,346.15 ns | 1,259.19 ns |  657936 B |
| Decrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 128KB        | 711,439.7 ns | 1,499.99 ns | 1,329.70 ns |         - |
|                                                 |              |              |             |             |           |
| Encrypt · AES-128-GCM-SIV (CryptoHives-ARM-AES) | 128KB        | 352,017.8 ns | 1,314.18 ns | 1,229.29 ns |         - |
| Encrypt · AES-128-GCM-SIV (BouncyCastle)        | 128KB        | 666,094.8 ns |   400.75 ns |   374.86 ns |  133428 B |
| Encrypt · AES-128-GCM-SIV (CryptoHives-Scalar)  | 128KB        | 675,708.0 ns | 2,041.59 ns | 1,909.70 ns |         - |