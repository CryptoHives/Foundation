| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Code Size | Allocated |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 4B           |         77.88 ns |      0.195 ns |      0.163 ns |  12,169 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 4B           |         82.40 ns |      0.095 ns |      0.084 ns |  11,852 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 4B           |         93.44 ns |      0.100 ns |      0.089 ns |   9,219 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 4B           |         95.36 ns |      0.237 ns |      0.198 ns |  15,706 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 4B           |        101.46 ns |      0.095 ns |      0.079 ns |  14,580 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 64B          |         79.75 ns |      0.054 ns |      0.050 ns |   5,689 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 64B          |         81.89 ns |      0.041 ns |      0.038 ns |  12,112 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64B          |         91.17 ns |      0.131 ns |      0.109 ns |  15,744 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64B          |         91.90 ns |      0.112 ns |      0.094 ns |  15,966 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64B          |         95.16 ns |      0.167 ns |      0.139 ns |   8,516 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 65B          |        156.05 ns |      0.126 ns |      0.112 ns |  11,958 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 65B          |        163.16 ns |      0.086 ns |      0.081 ns |  11,856 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 65B          |        171.25 ns |      0.145 ns |      0.129 ns |  15,744 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 65B          |        175.91 ns |      0.105 ns |      0.093 ns |  14,580 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 65B          |        182.35 ns |      0.486 ns |      0.431 ns |  15,710 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128B         |        152.05 ns |      0.106 ns |      0.094 ns |  12,022 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128B         |        158.63 ns |      0.121 ns |      0.107 ns |  12,110 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |        165.55 ns |      0.182 ns |      0.152 ns |  15,744 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |        176.00 ns |      0.059 ns |      0.052 ns |  14,851 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |        179.82 ns |      0.510 ns |      0.452 ns |  15,774 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 129B         |        230.87 ns |      0.153 ns |      0.143 ns |   5,433 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 129B         |        239.06 ns |      0.141 ns |      0.118 ns |  11,856 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 129B         |        245.31 ns |      0.182 ns |      0.162 ns |  15,554 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 129B         |        253.59 ns |      0.179 ns |      0.167 ns |  14,770 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 129B         |        269.67 ns |      0.588 ns |      0.550 ns |   9,185 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1KB          |      1,184.67 ns |      0.767 ns |      0.717 ns |  12,022 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1KB          |      1,225.16 ns |      1.451 ns |      1.357 ns |  12,110 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |      1,228.87 ns |      0.341 ns |      0.285 ns |  15,554 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |      1,267.66 ns |      0.554 ns |      0.491 ns |   8,516 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |      1,393.14 ns |      2.106 ns |      1.867 ns |  15,964 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1025B        |      1,265.52 ns |      0.640 ns |      0.599 ns |  11,958 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |      1,307.05 ns |      0.850 ns |      0.795 ns |   9,219 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1025B        |      1,308.02 ns |      0.966 ns |      0.904 ns |  12,046 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |      1,347.03 ns |      0.654 ns |      0.612 ns |  14,580 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |      1,480.70 ns |      2.365 ns |      1.846 ns |  15,710 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 8KB          |      9,453.38 ns |      5.177 ns |      4.843 ns |  12,212 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |      9,730.97 ns |      4.005 ns |      3.746 ns |  15,744 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 8KB          |      9,763.34 ns |     11.882 ns |     10.533 ns |  12,110 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |     10,015.28 ns |      3.553 ns |      3.323 ns |   8,516 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |     11,100.47 ns |     30.865 ns |     27.361 ns |   9,439 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 64KB         |     75,462.03 ns |     53.558 ns |     50.098 ns |   5,701 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64KB         |     77,793.38 ns |     41.191 ns |     38.530 ns |  15,744 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 64KB         |     78,113.27 ns |     55.295 ns |     51.723 ns |   5,789 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64KB         |     80,003.74 ns |     55.312 ns |     51.739 ns |  14,851 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64KB         |     88,918.03 ns |    197.624 ns |    165.025 ns |  15,978 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128KB        |    151,865.10 ns |    116.065 ns |    108.568 ns |  12,029 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        |    155,542.92 ns |     63.089 ns |     59.014 ns |  15,744 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128KB        |    156,140.27 ns |    182.197 ns |    170.427 ns |   5,782 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        |    160,012.85 ns |     88.194 ns |     78.182 ns |  15,046 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        |    177,596.02 ns |    465.981 ns |    413.080 ns |  15,978 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1MB          |  1,151,255.66 ns |  1,846.165 ns |  1,636.578 ns |  12,219 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1MB          |  1,187,075.36 ns |    531.951 ns |    497.587 ns |  15,744 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1MB          |  1,192,020.31 ns |    966.319 ns |    903.895 ns |  12,117 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1MB          |  1,221,450.34 ns |    772.656 ns |    722.743 ns |  14,856 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1MB          |  1,357,156.14 ns |  5,305.653 ns |  4,430.461 ns |  15,781 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 10MB         | 11,521,757.14 ns |  6,110.753 ns |  5,417.023 ns |   5,694 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 10MB         | 11,874,012.05 ns |  7,409.800 ns |  6,568.595 ns |  15,744 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 10MB         | 11,917,577.40 ns |  9,106.256 ns |  8,517.997 ns |   5,782 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 10MB         | 12,248,081.98 ns |  7,437.961 ns |  6,957.474 ns |  14,807 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 10MB         | 13,606,142.52 ns | 26,003.594 ns | 23,051.509 ns |  15,781 B |         - |