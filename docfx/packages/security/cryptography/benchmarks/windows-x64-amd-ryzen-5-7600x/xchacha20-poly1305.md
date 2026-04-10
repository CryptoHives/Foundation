| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     719.9 ns |     3.45 ns |     3.23 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     769.9 ns |     1.96 ns |     1.53 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     915.6 ns |     6.12 ns |     5.73 ns |      48 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,092.9 ns |     2.86 ns |     2.39 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128B         |     685.4 ns |     3.04 ns |     2.54 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128B         |     741.2 ns |     2.03 ns |     1.80 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128B         |     870.5 ns |     2.97 ns |     2.78 ns |      48 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128B         |   1,059.0 ns |     6.85 ns |     6.07 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,644.7 ns |    10.46 ns |     9.27 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   2,100.7 ns |    15.89 ns |    14.08 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,077.0 ns |    22.97 ns |    19.18 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,725.2 ns |    51.50 ns |    48.18 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 1KB          |   1,610.3 ns |     5.18 ns |     4.59 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 1KB          |   2,070.6 ns |     6.80 ns |     6.36 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 1KB          |   4,049.9 ns |    22.09 ns |    20.66 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 1KB          |   4,662.7 ns |    26.60 ns |    24.88 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   9,064.3 ns |    39.06 ns |    36.54 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  12,745.3 ns |    38.69 ns |    34.30 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  29,000.1 ns |   119.42 ns |    99.72 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  33,605.4 ns |   271.30 ns |   240.50 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 8KB          |   9,017.9 ns |    26.20 ns |    23.22 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 8KB          |  12,674.3 ns |    33.38 ns |    29.59 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 8KB          |  29,211.7 ns |   120.68 ns |   100.77 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 8KB          |  33,560.7 ns |   156.01 ns |   145.93 ns |         - |
|                                          |              |              |             |             |           |
| Decrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 136,693.2 ns |   840.75 ns |   786.44 ns |         - |
| Decrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 194,858.0 ns |   676.46 ns |   632.77 ns |         - |
| Decrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 478,772.1 ns | 1,504.35 ns | 1,407.17 ns |      72 B |
| Decrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 528,835.1 ns | 3,406.89 ns | 3,186.81 ns |         - |
|                                          |              |              |             |             |           |
| Encrypt · XChaCha20-Poly1305 (AVX2)      | 128KB        | 135,868.4 ns |   156.19 ns |   121.94 ns |         - |
| Encrypt · XChaCha20-Poly1305 (SSSE3)     | 128KB        | 195,019.6 ns |   729.04 ns |   681.94 ns |         - |
| Encrypt · XChaCha20-Poly1305 (NaCl.Core) | 128KB        | 458,784.9 ns | 3,121.75 ns | 2,767.35 ns |      72 B |
| Encrypt · XChaCha20-Poly1305 (Managed)   | 128KB        | 528,208.6 ns | 1,944.21 ns | 1,818.61 ns |         - |