| Description                             | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|---------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| Decrypt · AES-192-GCM (ArmAes+ArmPmull) | 17B          |      82.04 ns |     0.445 ns |     0.416 ns |      81.89 ns |         - |
| Decrypt · AES-192-GCM (Managed)         | 17B          |     371.81 ns |     0.964 ns |     0.752 ns |     372.03 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)    | 17B          |     624.67 ns |     2.119 ns |     1.879 ns |     623.96 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)              | 17B          |   1,925.40 ns |    17.206 ns |    16.094 ns |   1,927.36 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (ArmAes+ArmPmull) | 17B          |     254.74 ns |     0.465 ns |     0.412 ns |     254.51 ns |         - |
| Encrypt · AES-192-GCM (Managed)         | 17B          |   1,608.59 ns |    19.011 ns |    17.783 ns |   1,611.46 ns |         - |
| Encrypt · AES-192-GCM (OS)              | 17B          |   2,303.71 ns |    80.030 ns |   223.092 ns |   2,354.96 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)    | 17B          |   2,524.75 ns |     4.076 ns |     3.613 ns |   2,523.79 ns |    1624 B |
|                                         |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (ArmAes+ArmPmull) | 65B          |     119.86 ns |     0.387 ns |     0.343 ns |     119.94 ns |         - |
| Decrypt · AES-192-GCM (Managed)         | 65B          |     651.45 ns |     1.328 ns |     1.109 ns |     651.20 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)    | 65B          |     863.70 ns |    16.963 ns |    24.327 ns |     854.11 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)              | 65B          |   1,924.23 ns |    32.562 ns |    30.458 ns |   1,920.53 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (ArmAes+ArmPmull) | 65B          |     101.50 ns |     0.554 ns |     0.433 ns |     101.58 ns |         - |
| Encrypt · AES-192-GCM (Managed)         | 65B          |     742.09 ns |     4.185 ns |     3.915 ns |     740.78 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)    | 65B          |   1,861.71 ns |   424.211 ns | 1,250.795 ns |   1,004.66 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)              | 65B          |   2,277.32 ns |    71.619 ns |   192.400 ns |   2,349.89 ns |         - |
|                                         |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (ArmAes+ArmPmull) | 128B         |     159.57 ns |     2.466 ns |     2.059 ns |     158.90 ns |         - |
| Decrypt · AES-192-GCM (Managed)         | 128B         |     932.85 ns |     4.098 ns |     3.422 ns |     931.35 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)    | 128B         |   1,066.19 ns |     1.225 ns |     1.146 ns |   1,065.96 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)              | 128B         |   1,909.83 ns |    12.667 ns |    10.578 ns |   1,909.93 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (ArmAes+ArmPmull) | 128B         |     137.61 ns |     0.964 ns |     0.902 ns |     137.44 ns |         - |
| Encrypt · AES-192-GCM (Managed)         | 128B         |   1,074.42 ns |     3.996 ns |     3.542 ns |   1,074.97 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)    | 128B         |   1,271.47 ns |     6.567 ns |     6.143 ns |   1,270.90 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)              | 128B         |   2,432.80 ns |    21.943 ns |    20.525 ns |   2,429.71 ns |         - |
|                                         |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (ArmAes+ArmPmull) | 152B         |     196.24 ns |     1.112 ns |     1.040 ns |     196.19 ns |         - |
| Decrypt · AES-192-GCM (Managed)         | 152B         |   1,132.78 ns |     1.061 ns |     0.940 ns |   1,133.06 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)    | 152B         |   1,209.02 ns |     0.777 ns |     0.649 ns |   1,209.01 ns |    1640 B |
| Decrypt · AES-192-GCM (OS)              | 152B         |   1,926.46 ns |     9.776 ns |     8.666 ns |   1,928.22 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (ArmAes+ArmPmull) | 152B         |     170.57 ns |     1.987 ns |     1.659 ns |     169.86 ns |         - |
| Encrypt · AES-192-GCM (Managed)         | 152B         |   1,295.30 ns |     3.954 ns |     3.087 ns |   1,296.33 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)    | 152B         |   5,459.54 ns |    14.133 ns |    13.220 ns |   5,460.17 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)              | 152B         |   8,167.08 ns |   102.394 ns |    95.779 ns |   8,145.52 ns |         - |
|                                         |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (ArmAes+ArmPmull) | 256B         |     263.45 ns |     1.963 ns |     1.836 ns |     263.31 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)    | 256B         |   1,632.74 ns |     0.448 ns |     0.397 ns |   1,632.80 ns |    1640 B |
| Decrypt · AES-192-GCM (Managed)         | 256B         |   1,694.01 ns |     0.517 ns |     0.458 ns |   1,694.15 ns |         - |
| Decrypt · AES-192-GCM (OS)              | 256B         |   1,938.34 ns |    21.466 ns |    19.029 ns |   1,935.70 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (ArmAes+ArmPmull) | 256B         |   1,084.32 ns |     0.929 ns |     0.823 ns |   1,084.53 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)    | 256B         |   1,605.75 ns |    10.122 ns |     7.903 ns |   1,603.49 ns |    1624 B |
| Encrypt · AES-192-GCM (OS)              | 256B         |   2,415.88 ns |    16.897 ns |    15.806 ns |   2,411.39 ns |         - |
| Encrypt · AES-192-GCM (Managed)         | 256B         |   7,814.87 ns |     2.166 ns |     1.920 ns |   7,814.94 ns |         - |
|                                         |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (ArmAes+ArmPmull) | 1KB          |     849.00 ns |     3.396 ns |     3.176 ns |     849.06 ns |         - |
| Decrypt · AES-192-GCM (OS)              | 1KB          |   2,079.32 ns |    22.645 ns |    20.074 ns |   2,074.50 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)    | 1KB          |   5,013.23 ns |     3.704 ns |     3.465 ns |   5,013.90 ns |    1640 B |
| Decrypt · AES-192-GCM (Managed)         | 1KB          |   6,101.80 ns |     1.567 ns |     1.389 ns |   6,102.02 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (ArmAes+ArmPmull) | 1KB          |     884.75 ns |     7.884 ns |     7.375 ns |     884.49 ns |         - |
| Encrypt · AES-192-GCM (OS)              | 1KB          |   2,614.93 ns |    13.374 ns |    11.855 ns |   2,615.90 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)    | 1KB          |   6,468.48 ns |    50.445 ns |    44.719 ns |   6,447.75 ns |    1624 B |
| Encrypt · AES-192-GCM (Managed)         | 1KB          |   7,220.48 ns |    90.916 ns |    85.043 ns |   7,176.90 ns |         - |
|                                         |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (OS)              | 8KB          |   3,007.79 ns |    20.712 ns |    18.360 ns |   3,002.69 ns |         - |
| Decrypt · AES-192-GCM (ArmAes+ArmPmull) | 8KB          |   6,308.71 ns |    29.151 ns |    27.267 ns |   6,320.44 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)    | 8KB          |  36,066.42 ns |    20.644 ns |    18.300 ns |  36,066.62 ns |    1640 B |
| Decrypt · AES-192-GCM (Managed)         | 8KB          |  46,954.59 ns |    20.787 ns |    19.444 ns |  46,953.34 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (ArmAes+ArmPmull) | 8KB          |   6,751.94 ns |   132.677 ns |   255.624 ns |   6,605.52 ns |         - |
| Encrypt · AES-192-GCM (OS)              | 8KB          |  13,533.73 ns |   127.474 ns |   113.002 ns |  13,507.57 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)    | 8KB          |  47,516.11 ns |   163.867 ns |   136.836 ns |  47,469.53 ns |    1624 B |
| Encrypt · AES-192-GCM (Managed)         | 8KB          |  56,363.90 ns |   243.825 ns |   190.362 ns |  56,325.70 ns |         - |
|                                         |              |               |              |              |               |           |
| Decrypt · AES-192-GCM (OS)              | 128KB        |  19,595.86 ns |   120.168 ns |   112.405 ns |  19,578.22 ns |         - |
| Decrypt · AES-192-GCM (ArmAes+ArmPmull) | 128KB        | 100,682.31 ns |   307.547 ns |   256.815 ns | 100,687.01 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle)    | 128KB        | 569,435.36 ns |   401.136 ns |   375.223 ns | 569,564.82 ns |    1640 B |
| Decrypt · AES-192-GCM (Managed)         | 128KB        | 747,591.70 ns |   113.232 ns |   105.918 ns | 747,564.33 ns |         - |
|                                         |              |               |              |              |               |           |
| Encrypt · AES-192-GCM (OS)              | 128KB        |  20,655.55 ns |   220.860 ns |   206.592 ns |  20,689.25 ns |         - |
| Encrypt · AES-192-GCM (ArmAes+ArmPmull) | 128KB        | 106,459.25 ns | 1,093.094 ns |   912.783 ns | 106,012.59 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle)    | 128KB        | 609,978.36 ns |   913.929 ns |   854.890 ns | 609,633.10 ns |    1624 B |
| Encrypt · AES-192-GCM (Managed)         | 128KB        | 747,381.37 ns |   902.260 ns |   753.428 ns | 747,352.86 ns |         - |