| Description                          | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CBC (AES-NI)       | 128B         |      17.97 ns |     0.065 ns |     0.054 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 128B         |     247.51 ns |     1.277 ns |     1.194 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 128B         |     446.64 ns |     0.511 ns |     0.427 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128B         |     705.91 ns |     5.750 ns |     4.489 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (AES-NI)       | 128B         |     146.39 ns |     2.859 ns |     2.674 ns |         - |
| Encrypt · AES-128-CBC (OS)           | 128B         |     280.22 ns |     1.672 ns |     1.482 ns |     128 B |
| Encrypt · AES-128-CBC (Managed)      | 128B         |     390.21 ns |     2.114 ns |     1.874 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128B         |     642.72 ns |     5.315 ns |     4.712 ns |     832 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-128-CBC (AES-NI)       | 1KB          |      77.58 ns |     0.195 ns |     0.152 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 1KB          |     298.96 ns |     2.105 ns |     1.866 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 1KB          |   3,165.77 ns |     9.899 ns |     9.260 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 1KB          |   3,994.10 ns |    23.014 ns |    21.527 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)           | 1KB          |     692.18 ns |     1.867 ns |     1.655 ns |     128 B |
| Encrypt · AES-128-CBC (AES-NI)       | 1KB          |   1,162.32 ns |     3.221 ns |     2.690 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 1KB          |   3,106.79 ns |     7.041 ns |     6.241 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 1KB          |   3,794.33 ns |    12.103 ns |    10.729 ns |     832 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-128-CBC (AES-NI)       | 8KB          |     564.20 ns |     0.994 ns |     0.830 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 8KB          |     743.71 ns |     2.485 ns |     2.324 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 8KB          |  24,753.31 ns |    45.583 ns |    38.064 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 8KB          |  29,869.06 ns |   560.531 ns |   496.896 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)           | 8KB          |   4,087.88 ns |    22.045 ns |    18.409 ns |     128 B |
| Encrypt · AES-128-CBC (AES-NI)       | 8KB          |   9,056.92 ns |    22.551 ns |    19.991 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 8KB          |  24,829.33 ns |    80.164 ns |    71.064 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 8KB          |  28,843.33 ns |    47.076 ns |    41.731 ns |     832 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)           | 128KB        |   8,387.58 ns |    17.616 ns |    15.616 ns |     128 B |
| Decrypt · AES-128-CBC (AES-NI)       | 128KB        |   8,978.18 ns |    35.325 ns |    31.315 ns |         - |
| Decrypt · AES-128-CBC (Managed)      | 128KB        | 396,466.66 ns |   899.004 ns |   840.929 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128KB        | 470,217.51 ns | 1,138.459 ns | 1,064.916 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)           | 128KB        |  64,422.80 ns | 1,241.632 ns | 1,219.449 ns |     128 B |
| Encrypt · AES-128-CBC (AES-NI)       | 128KB        | 145,282.81 ns |   267.004 ns |   236.692 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 128KB        | 399,122.04 ns | 1,259.893 ns | 1,116.862 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128KB        | 461,056.08 ns | 1,155.494 ns | 1,080.850 ns |     832 B |