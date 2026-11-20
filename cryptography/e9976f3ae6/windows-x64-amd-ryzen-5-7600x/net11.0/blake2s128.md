| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Code Size | Allocated |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 4B           |         77.48 ns |      0.102 ns |      0.095 ns |  12,149 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 4B           |         81.81 ns |      0.091 ns |      0.080 ns |  11,852 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 4B           |         92.05 ns |      0.149 ns |      0.140 ns |  15,744 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 4B           |         95.04 ns |      0.246 ns |      0.205 ns |  15,516 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 4B           |         96.05 ns |      0.097 ns |      0.076 ns |  14,770 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 64B          |         79.27 ns |      0.071 ns |      0.066 ns |  12,214 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 64B          |         81.14 ns |      0.057 ns |      0.054 ns |  12,302 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64B          |         89.54 ns |      0.096 ns |      0.080 ns |  15,744 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64B          |         93.83 ns |      0.237 ns |      0.210 ns |   9,441 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64B          |         94.21 ns |      0.076 ns |      0.063 ns |   8,516 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 65B          |        156.30 ns |      0.100 ns |      0.083 ns |  11,768 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 65B          |        163.76 ns |      0.120 ns |      0.112 ns |   5,521 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 65B          |        168.54 ns |      0.217 ns |      0.192 ns |  15,554 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 65B          |        175.06 ns |      0.148 ns |      0.131 ns |  14,579 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 65B          |        184.24 ns |      0.395 ns |      0.350 ns |  15,520 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128B         |        151.41 ns |      0.049 ns |      0.041 ns |  12,212 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128B         |        157.61 ns |      0.080 ns |      0.075 ns |  12,110 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |        164.23 ns |      0.134 ns |      0.118 ns |  15,744 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |        173.43 ns |      0.160 ns |      0.150 ns |   8,516 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |        181.00 ns |      1.035 ns |      0.808 ns |   9,439 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 129B         |        229.92 ns |      0.160 ns |      0.142 ns |  11,958 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 129B         |        238.56 ns |      0.106 ns |      0.100 ns |  11,856 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 129B         |        244.98 ns |      0.242 ns |      0.226 ns |  15,744 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 129B         |        252.41 ns |      0.136 ns |      0.128 ns |   8,245 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 129B         |        269.57 ns |      0.486 ns |      0.454 ns |  15,710 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1KB          |      1,184.58 ns |      0.743 ns |      0.695 ns |   5,687 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1KB          |      1,225.22 ns |      0.693 ns |      0.614 ns |  12,110 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |      1,227.29 ns |      0.758 ns |      0.709 ns |  15,744 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |      1,269.74 ns |      0.667 ns |      0.591 ns |  10,086 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |      1,393.88 ns |      3.063 ns |      2.716 ns |  15,774 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1025B        |      1,267.14 ns |      1.332 ns |      1.113 ns |  11,958 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |      1,307.23 ns |      0.656 ns |      0.614 ns |  15,554 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1025B        |      1,308.41 ns |      1.933 ns |      1.808 ns |  11,856 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |      1,348.57 ns |      0.640 ns |      0.568 ns |  14,770 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |      1,483.76 ns |      2.165 ns |      1.690 ns |  15,520 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 8KB          |      9,453.84 ns |      5.767 ns |      5.394 ns |   5,687 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |      9,727.19 ns |      5.432 ns |      5.081 ns |   9,219 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 8KB          |      9,763.38 ns |      9.650 ns |      9.027 ns |  12,300 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |     10,014.84 ns |      4.082 ns |      3.409 ns |  15,041 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |     11,157.44 ns |     18.796 ns |     15.695 ns |  15,774 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 64KB         |     75,555.34 ns |     42.919 ns |     38.047 ns |   5,687 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64KB         |     77,798.42 ns |     47.675 ns |     44.595 ns |   9,219 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 64KB         |     78,045.52 ns |     89.907 ns |     79.700 ns |  12,124 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64KB         |     80,221.87 ns |     40.847 ns |     38.209 ns |  15,040 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64KB         |     88,790.72 ns |    130.281 ns |    108.791 ns |   9,453 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128KB        |    150,927.05 ns |    246.720 ns |    218.711 ns |   5,701 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        |    155,876.65 ns |    103.679 ns |     96.981 ns |  15,554 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128KB        |    156,158.15 ns |    149.106 ns |    139.474 ns |   5,775 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        |    160,033.14 ns |     91.762 ns |     85.834 ns |  14,856 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        |    177,865.20 ns |    656.955 ns |    512.908 ns |   9,439 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1MB          |  1,152,347.68 ns |    816.785 ns |    764.021 ns |  12,040 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1MB          |  1,187,411.28 ns |  1,149.634 ns |  1,075.368 ns |  15,554 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1MB          |  1,191,562.25 ns |    656.207 ns |    613.817 ns |  12,318 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1MB          |  1,221,283.49 ns |    629.551 ns |    588.882 ns |   8,521 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1MB          |  1,353,160.24 ns |  2,930.484 ns |  2,597.798 ns |  15,781 B |         - |
|                                                   |              |                  |               |               |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 10MB         | 11,521,553.33 ns |  6,241.590 ns |  5,838.387 ns |  12,170 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 10MB         | 11,906,961.83 ns |  6,211.674 ns |  5,506.487 ns |  15,695 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 10MB         | 11,907,634.62 ns | 34,476.629 ns | 28,789.547 ns |  12,117 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 10MB         | 12,216,389.06 ns |  6,435.116 ns |  6,019.412 ns |   8,520 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 10MB         | 13,563,704.69 ns | 27,722.214 ns | 24,575.021 ns |   9,357 B |         - |