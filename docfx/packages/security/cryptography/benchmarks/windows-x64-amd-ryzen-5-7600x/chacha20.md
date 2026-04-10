| Description                       | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|---------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| Decrypt · ChaCha20 (AVX2)         | 128B         |      70.12 ns |     0.493 ns |     0.461 ns |      69.99 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128B         |     127.37 ns |     1.231 ns |     1.092 ns |     126.95 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128B         |     279.30 ns |     2.307 ns |     2.158 ns |     279.95 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128B         |     324.39 ns |     5.726 ns |     5.623 ns |     322.89 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128B         |     470.38 ns |     4.817 ns |     4.270 ns |     469.63 ns |         - |
|                                   |              |               |              |              |               |           |
| Encrypt · ChaCha20 (AVX2)         | 128B         |      69.17 ns |     1.358 ns |     1.333 ns |      68.50 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128B         |     127.11 ns |     1.746 ns |     1.548 ns |     126.94 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128B         |     279.57 ns |     4.114 ns |     3.848 ns |     280.01 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128B         |     340.80 ns |     3.189 ns |     2.983 ns |     341.99 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128B         |     461.23 ns |     3.161 ns |     2.956 ns |     461.71 ns |         - |
|                                   |              |               |              |              |               |           |
| Decrypt · ChaCha20 (AVX2)         | 1KB          |     521.24 ns |     2.082 ns |     1.845 ns |     521.17 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 1KB          |   1,005.15 ns |     9.070 ns |     8.484 ns |   1,005.72 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,730.31 ns |    10.702 ns |    10.011 ns |   1,731.61 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,823.63 ns |    19.182 ns |    17.005 ns |   1,821.85 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 1KB          |   3,612.64 ns |    19.398 ns |    16.198 ns |   3,612.45 ns |         - |
|                                   |              |               |              |              |               |           |
| Encrypt · ChaCha20 (AVX2)         | 1KB          |     526.30 ns |     4.133 ns |     3.664 ns |     526.31 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 1KB          |   1,039.78 ns |    20.771 ns |    35.828 ns |   1,023.34 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,634.11 ns |     9.348 ns |     8.744 ns |   1,633.74 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,819.59 ns |    10.301 ns |     9.132 ns |   1,820.91 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 1KB          |   3,641.49 ns |    40.825 ns |    36.191 ns |   3,630.85 ns |         - |
|                                   |              |               |              |              |               |           |
| Decrypt · ChaCha20 (AVX2)         | 8KB          |   4,176.34 ns |    55.542 ns |    51.954 ns |   4,160.01 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 8KB          |   8,040.08 ns |    63.885 ns |    56.632 ns |   8,037.37 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,506.20 ns |   101.786 ns |    95.210 ns |  11,517.73 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,747.67 ns |   119.079 ns |   111.386 ns |  13,772.60 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 8KB          |  29,171.47 ns |   327.772 ns |   306.598 ns |  29,070.84 ns |         - |
|                                   |              |               |              |              |               |           |
| Encrypt · ChaCha20 (AVX2)         | 8KB          |   4,161.36 ns |    31.554 ns |    29.516 ns |   4,155.79 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 8KB          |   8,026.71 ns |    65.244 ns |    61.029 ns |   8,047.49 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,406.52 ns |    73.258 ns |    68.526 ns |  11,442.41 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,787.15 ns |    91.506 ns |    76.412 ns |  13,782.33 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 8KB          |  28,979.52 ns |   222.988 ns |   208.583 ns |  28,950.19 ns |         - |
|                                   |              |               |              |              |               |           |
| Decrypt · ChaCha20 (AVX2)         | 128KB        |  66,283.59 ns |   613.973 ns |   479.349 ns |  66,305.37 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128KB        | 132,701.25 ns | 2,591.866 ns | 3,879.383 ns | 133,261.98 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128KB        | 182,499.04 ns | 2,563.987 ns | 2,398.355 ns | 182,182.15 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128KB        | 221,784.90 ns | 3,756.761 ns | 3,514.077 ns | 220,462.28 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128KB        | 461,971.18 ns | 3,670.026 ns | 3,253.382 ns | 461,764.70 ns |         - |
|                                   |              |               |              |              |               |           |
| Encrypt · ChaCha20 (AVX2)         | 128KB        |  66,479.75 ns |   598.582 ns |   559.914 ns |  66,408.01 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128KB        | 128,496.74 ns | 1,220.911 ns | 1,142.041 ns | 128,389.09 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128KB        | 182,162.84 ns | 1,584.768 ns | 1,482.393 ns | 182,049.39 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128KB        | 219,894.35 ns | 1,293.414 ns | 1,146.577 ns | 220,064.40 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128KB        | 464,570.60 ns | 5,327.031 ns | 4,982.908 ns | 463,129.71 ns |         - |