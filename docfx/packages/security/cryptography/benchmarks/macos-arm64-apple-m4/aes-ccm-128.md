| Description                          | TestDataSize | Mean           | Error       | StdDev      | Median         | Allocated |
|------------------------------------- |------------- |---------------:|------------:|------------:|---------------:|----------:|
| Decrypt · AES-128-CCM (ArmAes)       | 128B         |       338.1 ns |     2.00 ns |     1.87 ns |       338.4 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 128B         |     1,167.4 ns |    23.01 ns |    24.62 ns |     1,173.8 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128B         |     1,765.3 ns |    30.78 ns |    28.79 ns |     1,768.7 ns |    2424 B |
|                                      |              |                |             |             |                |           |
| Encrypt · AES-128-CCM (ArmAes)       | 128B         |       243.7 ns |     0.31 ns |     0.28 ns |       243.7 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 128B         |     1,053.0 ns |    20.88 ns |    49.63 ns |     1,065.3 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128B         |     1,674.9 ns |    33.46 ns |    76.20 ns |     1,681.7 ns |    2464 B |
|                                      |              |                |             |             |                |           |
| Decrypt · AES-128-CCM (ArmAes)       | 1KB          |     1,868.2 ns |    36.43 ns |    34.08 ns |     1,872.3 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 1KB          |     7,386.3 ns |    98.31 ns |    91.96 ns |     7,384.7 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 1KB          |     8,602.2 ns |   163.66 ns |   181.91 ns |     8,655.7 ns |    2424 B |
|                                      |              |                |             |             |                |           |
| Encrypt · AES-128-CCM (ArmAes)       | 1KB          |     1,801.2 ns |    35.89 ns |    70.84 ns |     1,833.0 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 1KB          |     7,265.1 ns |    76.90 ns |    68.17 ns |     7,286.9 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 1KB          |     8,152.0 ns |   152.73 ns |   156.84 ns |     8,170.1 ns |    2464 B |
|                                      |              |                |             |             |                |           |
| Decrypt · AES-128-CCM (ArmAes)       | 8KB          |    13,978.8 ns |   223.71 ns |   209.26 ns |    13,951.5 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 8KB          |    56,865.3 ns |   547.17 ns |   485.05 ns |    56,728.8 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 8KB          |    61,988.0 ns | 1,228.26 ns | 1,462.15 ns |    62,780.1 ns |    2424 B |
|                                      |              |                |             |             |                |           |
| Encrypt · AES-128-CCM (ArmAes)       | 8KB          |    14,243.5 ns |   190.15 ns |   177.87 ns |    14,239.6 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 8KB          |    55,840.8 ns |   982.62 ns |   919.14 ns |    56,274.4 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 8KB          |    62,328.0 ns |   333.19 ns |   295.36 ns |    62,331.5 ns |    2464 B |
|                                      |              |                |             |             |                |           |
| Decrypt · AES-128-CCM (ArmAes)       | 128KB        |   224,550.1 ns | 4,112.89 ns | 3,847.20 ns |   226,120.3 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 128KB        |   907,723.0 ns | 1,401.84 ns | 1,170.60 ns |   907,361.8 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128KB        |   997,204.3 ns | 8,511.50 ns | 7,545.23 ns |   996,690.9 ns |    2424 B |
|                                      |              |                |             |             |                |           |
| Encrypt · AES-128-CCM (ArmAes)       | 128KB        |   221,443.5 ns | 2,008.53 ns | 1,878.78 ns |   222,253.3 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 128KB        |   911,833.9 ns | 9,849.66 ns | 8,731.47 ns |   910,736.0 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128KB        | 1,007,168.8 ns | 5,884.60 ns | 4,913.90 ns | 1,007,230.6 ns |    2464 B |