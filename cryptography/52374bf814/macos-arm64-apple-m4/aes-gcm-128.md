| Description                             | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|---------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-GCM (ArmAes+ArmPmull) | 17B          |      83.46 ns |     0.140 ns |     0.131 ns |         - |
| Decrypt · AES-128-GCM (Managed)         | 17B          |     349.10 ns |     0.676 ns |     0.599 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)    | 17B          |     571.92 ns |     1.796 ns |     1.592 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)              | 17B          |   1,876.11 ns |     7.974 ns |     7.459 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · AES-128-GCM (ArmAes+ArmPmull) | 17B          |      52.02 ns |     0.134 ns |     0.125 ns |         - |
| Encrypt · AES-128-GCM (Managed)         | 17B          |     313.23 ns |     0.600 ns |     0.561 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)    | 17B          |     489.69 ns |     2.913 ns |     2.725 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)              | 17B          |   1,667.75 ns |     5.798 ns |     4.841 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · AES-128-GCM (ArmAes+ArmPmull) | 65B          |     117.63 ns |     0.446 ns |     0.417 ns |         - |
| Decrypt · AES-128-GCM (Managed)         | 65B          |     608.52 ns |     0.821 ns |     0.768 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)    | 65B          |     770.15 ns |     2.003 ns |     1.874 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)              | 65B          |   1,878.06 ns |    10.164 ns |     9.507 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · AES-128-GCM (ArmAes+ArmPmull) | 65B          |      81.43 ns |     0.412 ns |     0.385 ns |         - |
| Encrypt · AES-128-GCM (Managed)         | 65B          |     571.55 ns |     0.691 ns |     0.647 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)    | 65B          |     700.34 ns |     1.246 ns |     1.165 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)              | 65B          |   1,670.34 ns |     8.758 ns |     8.192 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · AES-128-GCM (ArmAes+ArmPmull) | 128B         |     150.28 ns |     0.719 ns |     0.673 ns |         - |
| Decrypt · AES-128-GCM (Managed)         | 128B         |     865.62 ns |     1.100 ns |     0.918 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)    | 128B         |     973.42 ns |     1.716 ns |     1.521 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)              | 128B         |   1,892.75 ns |    15.790 ns |    14.770 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · AES-128-GCM (ArmAes+ArmPmull) | 128B         |     114.82 ns |     0.541 ns |     0.506 ns |         - |
| Encrypt · AES-128-GCM (Managed)         | 128B         |     834.97 ns |     0.197 ns |     0.174 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)    | 128B         |     916.07 ns |     1.968 ns |     1.840 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)              | 128B         |   1,675.67 ns |     7.713 ns |     7.215 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · AES-128-GCM (ArmAes+ArmPmull) | 152B         |     180.33 ns |     0.965 ns |     0.903 ns |         - |
| Decrypt · AES-128-GCM (Managed)         | 152B         |   1,049.62 ns |     2.411 ns |     2.138 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)    | 152B         |   1,097.85 ns |     1.020 ns |     0.954 ns |    1536 B |
| Decrypt · AES-128-GCM (OS)              | 152B         |   1,915.24 ns |    23.454 ns |    20.792 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · AES-128-GCM (ArmAes+ArmPmull) | 152B         |     141.78 ns |     0.931 ns |     0.871 ns |         - |
| Encrypt · AES-128-GCM (Managed)         | 152B         |     998.72 ns |     1.057 ns |     0.937 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)    | 152B         |   1,044.79 ns |     2.014 ns |     1.884 ns |    1520 B |
| Encrypt · AES-128-GCM (OS)              | 152B         |   1,693.58 ns |     9.880 ns |     9.242 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · AES-128-GCM (ArmAes+ArmPmull) | 256B         |     245.16 ns |     2.051 ns |     1.919 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)    | 256B         |   1,505.57 ns |    21.598 ns |    20.202 ns |    1536 B |
| Decrypt · AES-128-GCM (Managed)         | 256B         |   1,576.52 ns |     7.472 ns |     6.623 ns |         - |
| Decrypt · AES-128-GCM (OS)              | 256B         |   1,928.80 ns |     9.036 ns |     8.011 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · AES-128-GCM (ArmAes+ArmPmull) | 256B         |     206.31 ns |     0.522 ns |     0.488 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)    | 256B         |   1,457.01 ns |     2.930 ns |     2.741 ns |    1520 B |
| Encrypt · AES-128-GCM (Managed)         | 256B         |   1,537.20 ns |     0.764 ns |     0.677 ns |         - |
| Encrypt · AES-128-GCM (OS)              | 256B         |   1,699.98 ns |     9.487 ns |     8.874 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · AES-128-GCM (ArmAes+ArmPmull) | 1KB          |     825.49 ns |     8.153 ns |     7.626 ns |         - |
| Decrypt · AES-128-GCM (OS)              | 1KB          |   2,043.39 ns |    11.923 ns |    11.152 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)    | 1KB          |   4,507.99 ns |     4.555 ns |     4.038 ns |    1536 B |
| Decrypt · AES-128-GCM (Managed)         | 1KB          |   5,632.19 ns |     3.065 ns |     2.559 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · AES-128-GCM (ArmAes+ArmPmull) | 1KB          |     773.43 ns |     0.084 ns |     0.070 ns |         - |
| Encrypt · AES-128-GCM (OS)              | 1KB          |   1,846.66 ns |     8.340 ns |     7.802 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)    | 1KB          |   4,720.98 ns |     2.953 ns |     2.618 ns |    1520 B |
| Encrypt · AES-128-GCM (Managed)         | 1KB          |   5,488.35 ns |     1.785 ns |     1.669 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)              | 8KB          |   2,980.11 ns |     8.988 ns |     7.968 ns |         - |
| Decrypt · AES-128-GCM (ArmAes+ArmPmull) | 8KB          |   6,154.80 ns |    54.469 ns |    48.286 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)    | 8KB          |  32,353.34 ns |    14.646 ns |    12.230 ns |    1536 B |
| Decrypt · AES-128-GCM (Managed)         | 8KB          |  43,234.55 ns |    74.420 ns |    65.972 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)              | 8KB          |   2,759.67 ns |    23.114 ns |    21.621 ns |         - |
| Encrypt · AES-128-GCM (ArmAes+ArmPmull) | 8KB          |   6,031.61 ns |     1.374 ns |     1.218 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)    | 8KB          |  34,591.45 ns |    15.798 ns |    14.004 ns |    1520 B |
| Encrypt · AES-128-GCM (Managed)         | 8KB          |  42,968.62 ns |    31.414 ns |    29.385 ns |         - |
|                                         |              |               |              |              |           |
| Decrypt · AES-128-GCM (OS)              | 128KB        |  20,417.54 ns |    92.491 ns |    81.991 ns |         - |
| Decrypt · AES-128-GCM (ArmAes+ArmPmull) | 128KB        |  98,744.15 ns |   770.397 ns |   720.630 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)    | 128KB        | 509,846.38 ns | 3,538.195 ns | 2,954.553 ns |    1536 B |
| Decrypt · AES-128-GCM (Managed)         | 128KB        | 687,721.49 ns |   520.607 ns |   434.731 ns |         - |
|                                         |              |               |              |              |           |
| Encrypt · AES-128-GCM (OS)              | 128KB        |  20,606.77 ns |   188.091 ns |   175.940 ns |         - |
| Encrypt · AES-128-GCM (ArmAes+ArmPmull) | 128KB        |  97,818.19 ns |   888.611 ns |   742.030 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)    | 128KB        | 548,420.82 ns |   578.240 ns |   540.886 ns |    1520 B |
| Encrypt · AES-128-GCM (Managed)         | 128KB        | 686,949.55 ns | 4,014.906 ns | 3,352.628 ns |         - |