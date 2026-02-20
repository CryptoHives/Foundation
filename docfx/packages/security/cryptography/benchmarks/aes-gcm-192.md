| Description                          | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-192-GCM (AES-NI)       | 128B         |     107.48 ns |     1.324 ns |     1.239 ns |         - |
| Decrypt · AES-192-GCM (OS)           | 128B         |     119.70 ns |     0.993 ns |     0.929 ns |         - |
| Decrypt · AES-192-GCM (Managed)      | 128B         |     550.28 ns |     3.522 ns |     3.294 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 128B         |     981.12 ns |     8.659 ns |     8.100 ns |    1728 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-192-GCM (AES-NI)       | 128B         |      72.66 ns |     0.325 ns |     0.304 ns |         - |
| Encrypt · AES-192-GCM (OS)           | 128B         |     121.60 ns |     1.097 ns |     1.026 ns |         - |
| Encrypt · AES-192-GCM (Managed)      | 128B         |     516.33 ns |     5.321 ns |     4.978 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 128B         |     882.49 ns |     8.101 ns |     7.577 ns |    1712 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)           | 1KB          |     187.58 ns |     1.067 ns |     0.946 ns |         - |
| Decrypt · AES-192-GCM (AES-NI)       | 1KB          |     295.77 ns |     2.805 ns |     2.624 ns |         - |
| Decrypt · AES-192-GCM (Managed)      | 1KB          |   3,554.68 ns |    26.750 ns |    25.022 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 1KB          |   4,205.58 ns |    32.915 ns |    29.178 ns |    1728 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)           | 1KB          |     174.52 ns |     2.114 ns |     1.977 ns |         - |
| Encrypt · AES-192-GCM (AES-NI)       | 1KB          |     252.27 ns |     1.186 ns |     1.109 ns |         - |
| Encrypt · AES-192-GCM (Managed)      | 1KB          |   3,521.75 ns |    26.843 ns |    25.109 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 1KB          |   4,105.06 ns |    38.636 ns |    36.140 ns |    1712 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)           | 8KB          |     754.53 ns |     8.520 ns |     7.970 ns |         - |
| Decrypt · AES-192-GCM (AES-NI)       | 8KB          |   1,907.27 ns |    14.729 ns |    13.056 ns |         - |
| Decrypt · AES-192-GCM (Managed)      | 8KB          |  27,812.75 ns |   199.688 ns |   186.788 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 8KB          |  29,477.00 ns |   238.658 ns |   223.241 ns |    1728 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)           | 8KB          |     682.38 ns |     5.654 ns |     5.289 ns |         - |
| Encrypt · AES-192-GCM (AES-NI)       | 8KB          |   1,787.69 ns |     6.976 ns |     6.525 ns |         - |
| Encrypt · AES-192-GCM (Managed)      | 8KB          |  27,620.93 ns |   196.839 ns |   184.123 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 8KB          |  29,565.71 ns |   261.200 ns |   244.327 ns |    1712 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-192-GCM (OS)           | 128KB        |  12,330.90 ns |    44.363 ns |    39.326 ns |         - |
| Decrypt · AES-192-GCM (AES-NI)       | 128KB        |  29,161.14 ns |   316.327 ns |   280.416 ns |         - |
| Decrypt · AES-192-GCM (Managed)      | 128KB        | 445,882.52 ns |   831.701 ns |   737.281 ns |         - |
| Decrypt · AES-192-GCM (BouncyCastle) | 128KB        | 473,855.06 ns | 1,843.888 ns | 1,539.730 ns |    1728 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-192-GCM (OS)           | 128KB        |  10,396.79 ns |   119.528 ns |   111.806 ns |         - |
| Encrypt · AES-192-GCM (AES-NI)       | 128KB        |  27,949.02 ns |   198.027 ns |   175.546 ns |         - |
| Encrypt · AES-192-GCM (Managed)      | 128KB        | 440,347.04 ns | 2,393.483 ns | 2,238.866 ns |         - |
| Encrypt · AES-192-GCM (BouncyCastle) | 128KB        | 468,546.31 ns | 5,309.136 ns | 4,966.169 ns |    1712 B |