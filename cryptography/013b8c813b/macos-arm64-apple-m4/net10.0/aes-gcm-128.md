| Description                                       | TestDataSize | Mean          | Error      | StdDev     | Allocated |
|-------------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      79.64 ns |   0.436 ns |   0.408 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     350.02 ns |   0.840 ns |   0.786 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 17B          |     572.51 ns |   0.736 ns |   0.688 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 17B          |   1,885.58 ns |  13.577 ns |  12.700 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 17B          |      52.51 ns |   0.043 ns |   0.040 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 17B          |     310.59 ns |   0.190 ns |   0.159 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 17B          |     496.23 ns |   0.478 ns |   0.447 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 17B          |   1,692.15 ns |   7.893 ns |   6.997 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |     114.79 ns |   0.411 ns |   0.384 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     605.83 ns |   0.505 ns |   0.473 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 65B          |     765.98 ns |   0.681 ns |   0.604 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 65B          |   1,876.95 ns |  18.788 ns |  17.574 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 65B          |      82.88 ns |   0.359 ns |   0.336 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 65B          |     572.53 ns |   0.763 ns |   0.676 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 65B          |     709.60 ns |   0.750 ns |   0.702 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 65B          |   1,696.23 ns |  12.227 ns |  11.437 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     147.79 ns |   0.908 ns |   0.850 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     863.46 ns |   1.779 ns |   1.486 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128B         |     969.52 ns |   1.201 ns |   1.124 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 128B         |   1,925.13 ns |  25.271 ns |  23.639 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128B         |     113.89 ns |   0.242 ns |   0.226 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128B         |     832.75 ns |   4.600 ns |   4.303 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128B         |     923.72 ns |   0.595 ns |   0.497 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 128B         |   1,715.82 ns |  14.610 ns |  13.667 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     185.84 ns |   1.189 ns |   1.112 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |   1,044.51 ns |   1.328 ns |   1.242 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 152B         |   1,093.77 ns |   0.668 ns |   0.625 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)                        | 152B         |   1,920.54 ns |  13.832 ns |  12.939 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 152B         |     145.46 ns |   0.762 ns |   0.712 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 152B         |   1,000.48 ns |   0.576 ns |   0.450 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 152B         |   1,058.16 ns |   1.101 ns |   1.030 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)                        | 152B         |   1,715.92 ns |   9.608 ns |   8.988 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     252.74 ns |   2.047 ns |   1.915 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 256B         |   1,475.79 ns |   0.551 ns |   0.488 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |   1,571.21 ns |   0.875 ns |   0.776 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 256B         |   1,925.63 ns |  14.809 ns |  13.852 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 256B         |     210.00 ns |   1.095 ns |   1.024 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 256B         |   1,482.78 ns |   0.960 ns |   0.851 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 256B         |   1,537.68 ns |   0.246 ns |   0.218 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 256B         |   1,751.74 ns |   8.227 ns |   7.696 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     818.30 ns |   4.786 ns |   4.477 ns |         - |
| Decrypt · AES-128-GCM (OS)                        | 1KB          |   2,040.43 ns |  18.153 ns |  16.981 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 1KB          |   4,497.94 ns |   2.218 ns |   1.966 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |   5,616.40 ns |   0.977 ns |   0.866 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 1KB          |     777.00 ns |   3.165 ns |   2.960 ns |         - |
| Encrypt · AES-128-GCM (OS)                        | 1KB          |   1,852.33 ns |  12.683 ns |  11.864 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 1KB          |   4,736.94 ns |   3.530 ns |   3.129 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 1KB          |   5,482.91 ns |   0.975 ns |   0.865 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-128-GCM (OS)                        | 8KB          |   2,906.59 ns |  13.994 ns |  13.090 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,139.28 ns |  19.513 ns |  18.252 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 8KB          |  32,159.29 ns |   8.218 ns |   7.285 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |  43,142.20 ns |  13.286 ns |  12.428 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-128-GCM (OS)                        | 8KB          |   2,746.25 ns |  19.581 ns |  17.358 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 8KB          |   6,089.00 ns |  35.385 ns |  31.368 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 8KB          |  34,529.97 ns |  16.794 ns |  14.023 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 8KB          |  42,980.38 ns |  61.427 ns |  54.454 ns |         - |
|                                                   |              |               |            |            |           |
| Decrypt · AES-128-GCM (OS)                        | 128KB        |  18,348.94 ns |  93.843 ns |  87.781 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  98,310.10 ns | 636.842 ns | 595.703 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)              | 128KB        | 508,739.90 ns | 210.798 ns | 197.181 ns |    1536 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 686,348.60 ns | 243.045 ns | 227.344 ns |         - |
|                                                   |              |               |            |            |           |
| Encrypt · AES-128-GCM (OS)                        | 128KB        |  19,632.89 ns |  78.093 ns |  65.211 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-ARM-AES+PMULL) | 128KB        |  97,961.03 ns | 609.987 ns | 540.737 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)              | 128KB        | 550,114.42 ns | 692.387 ns | 647.660 ns |    1520 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)        | 128KB        | 685,222.76 ns |  88.668 ns |  78.602 ns |         - |