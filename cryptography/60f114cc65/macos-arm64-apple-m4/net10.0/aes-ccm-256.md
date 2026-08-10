| Description                          | TestDataSize | Mean           | Error        | StdDev       | Median         | Allocated |
|------------------------------------- |------------- |---------------:|-------------:|-------------:|---------------:|----------:|
| Decrypt · AES-256-CCM (ArmAes)       | 128B         |       375.6 ns |      7.48 ns |      6.99 ns |       375.6 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 128B         |     1,536.9 ns |      1.14 ns |      0.89 ns |     1,537.1 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128B         |     2,271.3 ns |     37.85 ns |     35.40 ns |     2,273.4 ns |    2808 B |
|                                      |              |                |              |              |                |           |
| Encrypt · AES-256-CCM (ArmAes)       | 128B         |       327.9 ns |      2.65 ns |      2.35 ns |       327.9 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 128B         |     1,477.9 ns |      8.24 ns |      6.88 ns |     1,479.2 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128B         |     2,195.3 ns |      8.38 ns |      7.00 ns |     2,192.9 ns |    2848 B |
|                                      |              |                |              |              |                |           |
| Decrypt · AES-256-CCM (ArmAes)       | 1KB          |     2,181.2 ns |     37.93 ns |     35.48 ns |     2,161.5 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 1KB          |     9,728.1 ns |     30.86 ns |     28.86 ns |     9,743.4 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 1KB          |    11,087.7 ns |     71.20 ns |     63.12 ns |    11,075.5 ns |    2808 B |
|                                      |              |                |              |              |                |           |
| Encrypt · AES-256-CCM (ArmAes)       | 1KB          |     1,996.5 ns |     25.05 ns |     20.92 ns |     2,000.4 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 1KB          |     9,603.6 ns |     33.40 ns |     26.07 ns |     9,608.3 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 1KB          |    11,000.0 ns |     67.21 ns |     62.87 ns |    10,978.4 ns |    2848 B |
|                                      |              |                |              |              |                |           |
| Decrypt · AES-256-CCM (ArmAes)       | 8KB          |    16,042.6 ns |    255.94 ns |    239.40 ns |    15,907.0 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 8KB          |    74,228.3 ns |  1,424.29 ns |  1,523.97 ns |    75,287.7 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 8KB          |    80,916.0 ns |    223.14 ns |    186.33 ns |    80,852.9 ns |    2808 B |
|                                      |              |                |              |              |                |           |
| Encrypt · AES-256-CCM (ArmAes)       | 8KB          |    15,743.5 ns |    247.58 ns |    231.59 ns |    15,727.4 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 8KB          |    74,855.9 ns |    457.30 ns |    427.76 ns |    75,070.2 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 8KB          |    81,642.8 ns |  1,056.13 ns |    987.90 ns |    81,477.6 ns |    2848 B |
|                                      |              |                |              |              |                |           |
| Decrypt · AES-256-CCM (ArmAes)       | 128KB        |   261,685.8 ns |  1,746.19 ns |  1,458.15 ns |   261,864.5 ns |         - |
| Decrypt · AES-256-CCM (Managed)      | 128KB        | 1,198,870.0 ns |  5,347.51 ns |  4,174.98 ns | 1,200,522.4 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,287,537.2 ns |  7,095.49 ns |  5,925.06 ns | 1,285,006.4 ns |    2808 B |
|                                      |              |                |              |              |                |           |
| Encrypt · AES-256-CCM (ArmAes)       | 128KB        |   257,193.6 ns |  4,926.22 ns |  6,049.84 ns |   255,910.9 ns |         - |
| Encrypt · AES-256-CCM (Managed)      | 128KB        | 1,197,913.4 ns |  3,026.30 ns |  2,527.10 ns | 1,198,744.0 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,293,258.8 ns | 17,045.11 ns | 15,110.05 ns | 1,290,403.4 ns |    2848 B |