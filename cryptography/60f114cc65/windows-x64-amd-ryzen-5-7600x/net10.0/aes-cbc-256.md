| Description                          | TestDataSize | Mean          | Error         | StdDev        | Allocated |
|------------------------------------- |------------- |--------------:|--------------:|--------------:|----------:|
| Decrypt · AES-256-CBC (AES-NI)       | 128B         |      55.84 ns |      0.197 ns |      0.165 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 128B         |     253.02 ns |      2.421 ns |      2.264 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 128B         |     568.95 ns |      5.295 ns |      4.953 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128B         |     891.00 ns |      3.653 ns |      3.050 ns |    1024 B |
|                                      |              |               |               |               |           |
| Encrypt · AES-256-CBC (AES-NI)       | 128B         |     201.60 ns |      1.454 ns |      1.360 ns |         - |
| Encrypt · AES-256-CBC (OS)           | 128B         |     322.08 ns |      5.441 ns |      4.823 ns |     128 B |
| Encrypt · AES-256-CBC (Managed)      | 128B         |     580.91 ns |     10.233 ns |      9.572 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128B         |     816.52 ns |      9.719 ns |      8.116 ns |    1024 B |
|                                      |              |               |               |               |           |
| Decrypt · AES-256-CBC (AES-NI)       | 1KB          |     291.47 ns |      1.225 ns |      1.086 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 1KB          |     327.47 ns |      2.343 ns |      2.192 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 1KB          |   4,077.49 ns |     29.423 ns |     26.083 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 1KB          |   4,852.72 ns |     40.772 ns |     36.143 ns |    1024 B |
|                                      |              |               |               |               |           |
| Encrypt · AES-256-CBC (OS)           | 1KB          |     907.88 ns |      3.697 ns |      3.277 ns |     128 B |
| Encrypt · AES-256-CBC (AES-NI)       | 1KB          |   1,403.07 ns |      9.955 ns |      9.312 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 1KB          |   4,114.58 ns |     81.348 ns |     83.539 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 1KB          |   4,884.58 ns |     78.941 ns |     73.841 ns |    1024 B |
|                                      |              |               |               |               |           |
| Decrypt · AES-256-CBC (OS)           | 8KB          |     936.36 ns |      3.693 ns |      2.883 ns |     128 B |
| Decrypt · AES-256-CBC (AES-NI)       | 8KB          |   2,204.33 ns |     10.433 ns |      9.249 ns |         - |
| Decrypt · AES-256-CBC (Managed)      | 8KB          |  31,595.87 ns |    305.788 ns |    286.035 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 8KB          |  36,495.84 ns |    271.182 ns |    253.664 ns |    1024 B |
|                                      |              |               |               |               |           |
| Encrypt · AES-256-CBC (OS)           | 8KB          |   5,891.17 ns |     27.781 ns |     25.987 ns |     128 B |
| Encrypt · AES-256-CBC (AES-NI)       | 8KB          |  10,883.98 ns |     66.606 ns |     62.303 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 8KB          |  32,620.43 ns |    636.639 ns |    653.782 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 8KB          |  37,411.33 ns |    715.743 ns |    852.041 ns |    1024 B |
|                                      |              |               |               |               |           |
| Decrypt · AES-256-CBC (OS)           | 128KB        |  11,307.32 ns |     45.564 ns |     38.048 ns |     128 B |
| Decrypt · AES-256-CBC (AES-NI)       | 128KB        |  34,788.16 ns |    151.095 ns |    141.334 ns |         - |
| Decrypt · AES-256-CBC (Managed)      | 128KB        | 502,755.93 ns |  5,732.514 ns |  5,362.197 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128KB        | 574,681.84 ns |  4,108.187 ns |  3,842.801 ns |    1024 B |
|                                      |              |               |               |               |           |
| Encrypt · AES-256-CBC (OS)           | 128KB        |  91,207.07 ns |    347.717 ns |    325.255 ns |     128 B |
| Encrypt · AES-256-CBC (AES-NI)       | 128KB        | 173,371.51 ns |  1,230.897 ns |  1,151.382 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 128KB        | 516,261.91 ns | 10,156.288 ns |  9,500.198 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128KB        | 589,764.70 ns | 11,125.691 ns | 10,406.978 ns |    1024 B |