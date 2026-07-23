| Description                                  | TestDataSize | Mean             | Error          | StdDev         | Allocated |
|--------------------------------------------- |------------- |-----------------:|---------------:|---------------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 4B           |         52.38 ns |       0.060 ns |       0.056 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 4B           |         53.90 ns |       0.054 ns |       0.051 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 4B           |         65.21 ns |       1.332 ns |       2.535 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 4B           |         69.47 ns |       0.071 ns |       0.066 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 4B           |        259.50 ns |       1.723 ns |       1.611 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 4B           |        327.45 ns |       1.110 ns |       1.039 ns |         - |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 100B         |        100.19 ns |       0.078 ns |       0.073 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 100B         |        109.06 ns |       0.125 ns |       0.104 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 100B         |        123.01 ns |       0.137 ns |       0.121 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 100B         |        163.60 ns |       0.081 ns |       0.072 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 100B         |        521.35 ns |       3.025 ns |       2.681 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 100B         |        712.87 ns |       1.558 ns |       1.457 ns |         - |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 128B         |        100.41 ns |       0.095 ns |       0.089 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 128B         |        109.00 ns |       0.032 ns |       0.029 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 128B         |        123.04 ns |       0.069 ns |       0.057 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128B         |        164.10 ns |       0.052 ns |       0.049 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128B         |        530.49 ns |       2.696 ns |       2.521 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128B         |        719.43 ns |       3.192 ns |       2.492 ns |         - |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 137B         |        147.52 ns |       0.205 ns |       0.171 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 137B         |        165.27 ns |       0.229 ns |       0.214 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 137B         |        182.77 ns |       0.045 ns |       0.042 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 137B         |        273.37 ns |       0.146 ns |       0.137 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 137B         |        768.38 ns |       2.465 ns |       2.306 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 137B         |      1,068.05 ns |       2.191 ns |       2.050 ns |         - |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1000B        |        776.56 ns |       0.390 ns |       0.345 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1000B        |        900.47 ns |       0.707 ns |       0.627 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1000B        |        969.10 ns |       0.443 ns |       0.415 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1000B        |      1,692.30 ns |       0.626 ns |       0.489 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1000B        |      4,031.05 ns |      16.967 ns |      15.871 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1000B        |      5,451.01 ns |      11.531 ns |      10.786 ns |         - |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1KB          |        776.97 ns |       0.518 ns |       0.459 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1KB          |        901.64 ns |       0.598 ns |       0.560 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1KB          |        975.59 ns |      14.078 ns |      11.756 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1KB          |      1,691.97 ns |       0.395 ns |       0.330 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1KB          |      4,039.94 ns |      20.943 ns |      19.590 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1KB          |      5,427.04 ns |      13.731 ns |      12.844 ns |         - |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1025B        |        877.46 ns |       0.334 ns |       0.296 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1025B        |      1,018.37 ns |       0.435 ns |       0.386 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1025B        |      1,143.64 ns |       4.959 ns |       4.638 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1025B        |      1,863.38 ns |       3.577 ns |       2.793 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1025B        |      4,578.15 ns |      17.874 ns |      16.720 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1025B        |      6,163.55 ns |       8.798 ns |       8.229 ns |      56 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 4KB          |      1,712.28 ns |       5.368 ns |       5.021 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 4KB          |      1,982.98 ns |       6.615 ns |       5.864 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 4KB          |      2,184.60 ns |      10.932 ns |      10.225 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 4KB          |      3,088.17 ns |      13.808 ns |      12.241 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 4KB          |     16,966.78 ns |      73.697 ns |      68.936 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 4KB          |     22,675.82 ns |      37.146 ns |      31.018 ns |     168 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 8KB          |      3,395.18 ns |      15.919 ns |      14.891 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 8KB          |      3,910.65 ns |      16.102 ns |      15.062 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 8KB          |      4,428.84 ns |      24.451 ns |      22.871 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 8KB          |      5,209.23 ns |      17.314 ns |      16.195 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 8KB          |     34,329.34 ns |     137.766 ns |     128.867 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 8KB          |     45,711.93 ns |     108.269 ns |     101.275 ns |     392 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 10000B       |      4,778.15 ns |      30.167 ns |      25.190 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 10000B       |      5,635.35 ns |      15.751 ns |      14.734 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 10000B       |      6,134.16 ns |      14.500 ns |      13.563 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 10000B       |      7,592.59 ns |      35.132 ns |      32.863 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 10000B       |     42,319.00 ns |     144.383 ns |     135.056 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 10000B       |     56,346.18 ns |      72.419 ns |      67.741 ns |     504 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 64KB         |     26,877.71 ns |     102.716 ns |      91.055 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 64KB         |     30,944.14 ns |     120.923 ns |     113.112 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 64KB         |     35,090.05 ns |     126.809 ns |     118.618 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 64KB         |     35,787.32 ns |     138.529 ns |     115.678 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 64KB         |    277,483.26 ns |   1,335.813 ns |   1,249.520 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 64KB         |    367,517.00 ns |     541.751 ns |     506.754 ns |    3528 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 100000B      |     41,679.94 ns |     170.918 ns |     159.876 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 100000B      |     47,952.62 ns |     194.686 ns |     172.584 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 100000B      |     53,051.32 ns |     166.257 ns |     155.517 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 100000B      |     53,506.01 ns |     162.978 ns |     152.450 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 100000B      |    423,775.65 ns |   2,138.799 ns |   1,895.990 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 100000B      |    560,992.82 ns |   1,143.930 ns |   1,070.032 ns |    5432 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 128KB        |     53,935.46 ns |     136.099 ns |     127.307 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 128KB        |     61,953.47 ns |     180.475 ns |     168.817 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128KB        |     68,566.36 ns |     318.467 ns |     297.894 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 128KB        |     69,444.55 ns |     280.901 ns |     262.755 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128KB        |    556,344.69 ns |   2,312.232 ns |   2,049.733 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128KB        |    736,539.32 ns |     950.638 ns |     793.825 ns |    7112 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 256KB        |    108,171.97 ns |     481.368 ns |     426.720 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 256KB        |    124,076.62 ns |     306.623 ns |     286.816 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 256KB        |    134,091.38 ns |     543.194 ns |     481.528 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 256KB        |    138,156.15 ns |     482.382 ns |     451.220 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 256KB        |  1,115,148.61 ns |   4,236.582 ns |   3,962.901 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 256KB        |  1,470,521.54 ns |   1,397.381 ns |   1,238.742 ns |   14280 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 512KB        |    216,395.87 ns |     682.998 ns |     638.877 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 512KB        |    248,135.55 ns |     640.005 ns |     598.661 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 512KB        |    265,209.72 ns |   1,277.504 ns |   1,194.978 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 512KB        |    275,909.94 ns |   1,236.999 ns |   1,157.089 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 512KB        |  2,229,347.59 ns |   9,969.826 ns |   8,325.256 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 512KB        |  2,947,275.79 ns |   4,649.074 ns |   4,348.747 ns |   28616 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1MB          |    412,843.40 ns |   1,901.815 ns |   1,778.959 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1MB          |    473,835.57 ns |     613.116 ns |     573.509 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1MB          |    501,653.92 ns |   2,692.538 ns |   2,518.602 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1MB          |    524,373.05 ns |   2,374.321 ns |   2,220.942 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1MB          |  4,247,034.94 ns |  16,678.480 ns |  15,601.061 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1MB          |  5,644,476.67 ns |   9,776.118 ns |   9,144.587 ns |   54656 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 10MB         |  4,129,491.37 ns |  17,197.333 ns |  15,244.988 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 10MB         |  4,741,187.67 ns |  12,107.919 ns |  10,110.661 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 10MB         |  5,014,961.19 ns |  32,824.954 ns |  30,704.483 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 10MB         |  5,252,358.48 ns |  16,129.769 ns |  15,087.796 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 10MB         | 42,557,445.83 ns | 146,895.887 ns | 137,406.504 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 10MB         | 56,401,950.31 ns |  84,839.965 ns |  79,359.356 ns |  546840 B |