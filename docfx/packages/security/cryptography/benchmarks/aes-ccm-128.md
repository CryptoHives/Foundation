| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CCM (Managed)      | 128B         |   1,020.0 ns |     6.91 ns |     6.47 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128B         |   1,615.7 ns |    17.17 ns |    15.22 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (Managed)      | 128B         |     984.8 ns |    10.62 ns |     9.42 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128B         |   1,579.0 ns |    14.42 ns |    13.49 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (Managed)      | 1KB          |   6,466.1 ns |    34.18 ns |    31.97 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 1KB          |   8,052.3 ns |    73.99 ns |    69.21 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (Managed)      | 1KB          |   6,439.2 ns |    48.41 ns |    45.28 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 1KB          |   8,032.7 ns |    58.07 ns |    51.48 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (Managed)      | 8KB          |  50,003.0 ns |   183.74 ns |   162.88 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 8KB          |  59,489.7 ns |   364.64 ns |   341.09 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (Managed)      | 8KB          |  50,327.6 ns |   575.61 ns |   480.66 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 8KB          |  59,262.4 ns |   219.67 ns |   194.74 ns |    2464 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CCM (Managed)      | 128KB        | 797,531.8 ns | 3,693.43 ns | 3,454.83 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128KB        | 935,267.3 ns | 5,982.01 ns | 5,302.90 ns |    2424 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CCM (Managed)      | 128KB        | 796,210.7 ns | 3,962.45 ns | 3,512.61 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128KB        | 941,280.8 ns | 8,439.10 ns | 7,893.94 ns |    2464 B |