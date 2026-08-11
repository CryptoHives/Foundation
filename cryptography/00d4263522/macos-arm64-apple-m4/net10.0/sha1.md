| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 128B         |     231.5 ns |     1.95 ns |     1.82 ns |         - |
| TryComputeHash · SHA-1 · OS Native          | 128B         |     272.1 ns |     3.03 ns |     2.84 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     487.2 ns |     2.29 ns |     1.79 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     530.6 ns |     1.98 ns |     1.55 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 137B         |     218.8 ns |     2.33 ns |     2.18 ns |         - |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     259.6 ns |     1.36 ns |     1.14 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     489.1 ns |     1.07 ns |     0.84 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     525.6 ns |     2.29 ns |     1.79 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |     532.0 ns |     7.55 ns |     7.06 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 1KB          |   1,222.2 ns |    14.83 ns |    13.15 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,734.4 ns |    34.45 ns |    32.22 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,905.1 ns |    43.73 ns |    40.91 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |     525.1 ns |     0.96 ns |     0.75 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 1025B        |   1,223.8 ns |    13.27 ns |    12.41 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,732.4 ns |    32.32 ns |    30.24 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,894.4 ns |    35.84 ns |    33.53 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   2,657.3 ns |    34.93 ns |    32.68 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 8KB          |   9,232.3 ns |    97.07 ns |    90.80 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  20,638.7 ns |   254.52 ns |   225.62 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  21,766.5 ns |   287.30 ns |   268.74 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        |  39,287.6 ns |   710.66 ns |   664.76 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 128KB        | 146,324.5 ns | 1,620.64 ns | 1,515.94 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 328,081.2 ns | 4,903.31 ns | 4,586.56 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 345,023.9 ns | 4,729.92 ns | 4,424.37 ns |         - |