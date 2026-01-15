```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7623/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                          | TestDataSize | Mean           | Error        | StdDev       | Median         | Allocated |
|----------------------------------------------------- |------------- |---------------:|-------------:|-------------:|---------------:|----------:|
| **ComputeHash | BLAKE2b-512 | BouncyCastle**             | **128B**         |       **141.2 ns** |      **0.61 ns** |      **0.55 ns** |       **141.1 ns** |     **176 B** |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2     | 128B         |       167.5 ns |      0.77 ns |      0.72 ns |       167.5 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar   | 128B         |       428.1 ns |      1.58 ns |      1.40 ns |       428.1 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle             | 137B         |       225.5 ns |      0.90 ns |      0.85 ns |       225.6 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2     | 137B         |       266.1 ns |      0.75 ns |      0.63 ns |       266.1 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar   | 137B         |       805.4 ns |      2.82 ns |      2.50 ns |       804.6 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle             | 1KB          |       756.7 ns |      2.84 ns |      2.65 ns |       756.6 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2     | 1KB          |       934.6 ns |      2.79 ns |      2.47 ns |       934.8 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar   | 1KB          |     3,095.0 ns |     10.22 ns |      9.06 ns |     3,093.5 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle             | 1025B        |       853.2 ns |      3.00 ns |      2.66 ns |       853.7 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2     | 1025B        |     1,046.0 ns |      3.19 ns |      2.82 ns |     1,045.5 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar   | 1025B        |     3,494.8 ns |     19.86 ns |     15.51 ns |     3,496.2 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle             | 8KB          |     5,684.1 ns |     10.67 ns |      9.98 ns |     5,684.0 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2     | 8KB          |     7,144.8 ns |     20.60 ns |     16.08 ns |     7,147.0 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar   | 8KB          |    24,446.7 ns |     98.48 ns |     82.24 ns |    24,476.8 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle             | 128KB        |    90,604.8 ns |    164.32 ns |    153.71 ns |    90,550.7 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2     | 128KB        |   113,621.9 ns |    232.87 ns |    181.81 ns |   113,668.4 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar   | 128KB        |   389,730.3 ns |  2,208.19 ns |  1,957.50 ns |   389,526.3 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2     | 128B         |       206.3 ns |      0.75 ns |      0.67 ns |       206.1 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BouncyCastle             | 128B         |       206.4 ns |      1.47 ns |      1.31 ns |       206.6 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2     | 128B         |       227.9 ns |      1.22 ns |      1.14 ns |       227.7 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar   | 128B         |       671.5 ns |      1.82 ns |      1.52 ns |       670.9 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle             | 137B         |       282.4 ns |      1.48 ns |      1.38 ns |       282.1 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2     | 137B         |       290.9 ns |      1.60 ns |      1.25 ns |       290.5 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2     | 137B         |       328.1 ns |      2.00 ns |      1.87 ns |       328.1 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar   | 137B         |       990.2 ns |      5.88 ns |      5.21 ns |       990.8 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle             | 1KB          |     1,286.8 ns |     11.03 ns |      9.78 ns |     1,283.6 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2     | 1KB          |     1,346.8 ns |      3.85 ns |      3.21 ns |     1,346.7 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2     | 1KB          |     1,546.3 ns |     23.81 ns |     18.59 ns |     1,541.6 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar   | 1KB          |     5,135.2 ns |     32.32 ns |     26.99 ns |     5,131.9 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle             | 1025B        |     1,349.5 ns |      3.34 ns |      2.96 ns |     1,349.6 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2     | 1025B        |     1,432.3 ns |     20.85 ns |     16.28 ns |     1,426.9 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2     | 1025B        |     1,639.1 ns |     20.06 ns |     16.75 ns |     1,641.5 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar   | 1025B        |     5,364.6 ns |     13.79 ns |     11.51 ns |     5,364.3 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle             | 8KB          |     9,755.6 ns |     19.56 ns |     18.30 ns |     9,759.5 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2     | 8KB          |    10,438.1 ns |     63.51 ns |     56.30 ns |    10,437.1 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2     | 8KB          |    11,904.4 ns |     48.97 ns |     45.81 ns |    11,893.4 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar   | 8KB          |    39,965.7 ns |    156.10 ns |    146.01 ns |    39,960.2 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle             | 128KB        |   156,777.8 ns |    548.84 ns |    513.38 ns |   156,790.2 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2     | 128KB        |   165,886.9 ns |    637.53 ns |    565.16 ns |   165,903.6 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2     | 128KB        |   189,695.9 ns |    698.11 ns |    653.01 ns |   189,540.8 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar   | 128KB        |   640,468.4 ns |  7,318.38 ns |  6,111.18 ns |   637,959.9 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                        | 128B         |       122.5 ns |      0.74 ns |      0.69 ns |       122.3 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3          | 128B         |       417.2 ns |      1.63 ns |      1.53 ns |       416.6 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar         | 128B         |       623.6 ns |      3.25 ns |      2.88 ns |       623.4 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                  | 128B         |     1,365.6 ns |      7.79 ns |      6.91 ns |     1,363.7 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                        | 137B         |       171.6 ns |      0.51 ns |      0.48 ns |       171.4 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3          | 137B         |       482.8 ns |      2.03 ns |      1.80 ns |       483.4 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar         | 137B         |       899.2 ns |      4.50 ns |      4.21 ns |       899.9 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                  | 137B         |     2,062.6 ns |     37.46 ns |     33.21 ns |     2,054.8 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                        | 1KB          |       772.3 ns |      2.32 ns |      2.05 ns |       771.6 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3          | 1KB          |     1,390.2 ns |      3.14 ns |      2.94 ns |     1,390.2 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar         | 1KB          |     4,590.0 ns |     31.43 ns |     29.40 ns |     4,578.1 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                  | 1KB          |    10,186.7 ns |     46.76 ns |     43.74 ns |    10,185.3 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                        | 1025B        |       881.6 ns |      2.42 ns |      2.26 ns |       881.3 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3          | 1025B        |     1,562.0 ns |      5.65 ns |      4.71 ns |     1,561.3 ns |     224 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar         | 1025B        |     5,143.6 ns |     34.89 ns |     27.24 ns |     5,136.3 ns |     224 B |
| ComputeHash | BLAKE3 | BouncyCastle                  | 1025B        |    11,831.5 ns |    214.92 ns |    558.59 ns |    11,516.0 ns |     168 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                        | 8KB          |     1,210.3 ns |      3.04 ns |      2.69 ns |     1,211.2 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3          | 8KB          |    11,185.6 ns |     27.65 ns |     24.51 ns |    11,182.9 ns |     896 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar         | 8KB          |    38,012.9 ns |    123.06 ns |    102.76 ns |    38,045.2 ns |     896 B |
| ComputeHash | BLAKE3 | BouncyCastle                  | 8KB          |    84,314.2 ns |    241.77 ns |    226.15 ns |    84,330.8 ns |     504 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                        | 128KB        |    14,836.7 ns |     56.09 ns |     52.47 ns |    14,845.6 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3          | 128KB        |   180,569.0 ns |    383.97 ns |    340.38 ns |   180,439.1 ns |   14336 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar         | 128KB        |   614,220.5 ns |  2,676.52 ns |  2,372.67 ns |   613,952.5 ns |   14336 B |
| ComputeHash | BLAKE3 | BouncyCastle                  | 128KB        | 1,378,444.2 ns |  4,605.99 ns |  4,083.09 ns | 1,379,736.1 ns |    7224 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE128 | CryptoHives**                | **128B**         |       **309.6 ns** |      **1.76 ns** |      **1.56 ns** |       **309.7 ns** |     **112 B** |
| **ComputeHash | CSHAKE128 | BouncyCastle**               | **128B**         |       **391.4 ns** |      **3.26 ns** |      **3.05 ns** |       **390.2 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE128 | CryptoHives**                | **137B**         |       **304.6 ns** |      **3.09 ns** |      **2.89 ns** |       **304.7 ns** |     **112 B** |
| **ComputeHash | CSHAKE128 | BouncyCastle**               | **137B**         |       **392.7 ns** |      **2.85 ns** |      **2.66 ns** |       **392.1 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE128 | CryptoHives**                | **1KB**          |     **1,647.1 ns** |     **12.45 ns** |     **11.04 ns** |     **1,646.0 ns** |     **112 B** |
| **ComputeHash | CSHAKE128 | BouncyCastle**               | **1KB**          |     **2,361.6 ns** |     **10.16 ns** |      **8.49 ns** |     **2,358.2 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE128 | CryptoHives**                | **1025B**        |     **1,643.0 ns** |      **8.29 ns** |      **7.35 ns** |     **1,643.2 ns** |     **112 B** |
| **ComputeHash | CSHAKE128 | BouncyCastle**               | **1025B**        |     **2,369.6 ns** |     **18.83 ns** |     **17.62 ns** |     **2,360.2 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE128 | CryptoHives**                | **8KB**          |    **10,605.8 ns** |     **71.55 ns** |     **63.43 ns** |    **10,615.0 ns** |     **112 B** |
| **ComputeHash | CSHAKE128 | BouncyCastle**               | **8KB**          |    **16,262.4 ns** |    **102.50 ns** |     **90.86 ns** |    **16,252.6 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE128 | CryptoHives**                | **128KB**        |   **168,742.7 ns** |  **1,132.64 ns** |  **1,004.06 ns** |   **168,767.1 ns** |     **112 B** |
| **ComputeHash | CSHAKE128 | BouncyCastle**               | **128KB**        |   **256,936.4 ns** |  **1,103.64 ns** |    **921.59 ns** |   **257,071.0 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE256 | CryptoHives**                | **128B**         |       **323.1 ns** |      **1.88 ns** |      **1.76 ns** |       **323.2 ns** |     **176 B** |
| **ComputeHash | CSHAKE256 | BouncyCastle**               | **128B**         |       **389.5 ns** |      **1.18 ns** |      **0.99 ns** |       **389.7 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE256 | CryptoHives**                | **137B**         |       **591.8 ns** |      **2.88 ns** |      **2.56 ns** |       **592.0 ns** |     **176 B** |
| **ComputeHash | CSHAKE256 | BouncyCastle**               | **137B**         |       **718.1 ns** |      **2.21 ns** |      **1.96 ns** |       **717.8 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE256 | CryptoHives**                | **1KB**          |     **1,827.0 ns** |     **12.79 ns** |     **10.68 ns** |     **1,828.2 ns** |     **176 B** |
| **ComputeHash | CSHAKE256 | BouncyCastle**               | **1KB**          |     **2,686.0 ns** |     **14.43 ns** |     **13.50 ns** |     **2,683.3 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE256 | CryptoHives**                | **1025B**        |     **1,833.6 ns** |      **8.09 ns** |      **7.18 ns** |     **1,832.9 ns** |     **176 B** |
| **ComputeHash | CSHAKE256 | BouncyCastle**               | **1025B**        |     **2,676.3 ns** |     **17.83 ns** |     **16.68 ns** |     **2,671.3 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE256 | CryptoHives**                | **8KB**          |    **13,144.2 ns** |     **83.62 ns** |     **78.22 ns** |    **13,134.3 ns** |     **176 B** |
| **ComputeHash | CSHAKE256 | BouncyCastle**               | **8KB**          |    **20,049.3 ns** |     **87.70 ns** |     **82.04 ns** |    **20,083.2 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE256 | CryptoHives**                | **128KB**        |   **206,770.6 ns** |  **1,469.66 ns** |  **1,374.72 ns** |   **206,415.2 ns** |     **176 B** |
| **ComputeHash | CSHAKE256 | BouncyCastle**               | **128KB**        |   **314,267.6 ns** |  **1,453.13 ns** |  **1,213.43 ns** |   **314,373.0 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | K12 | CryptoHives**                      | **128B**         |       **320.8 ns** |      **2.44 ns** |      **2.17 ns** |       **320.1 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | K12 | CryptoHives                      | 137B         |       329.4 ns |      2.05 ns |      1.82 ns |       328.8 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | K12 | CryptoHives                      | 1KB          |       915.5 ns |     12.20 ns |     10.82 ns |       912.5 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | K12 | CryptoHives                      | 1025B        |       926.4 ns |     14.98 ns |     13.28 ns |       932.8 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | K12 | CryptoHives                      | 8KB          |     6,041.2 ns |     35.13 ns |     31.14 ns |     6,023.7 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | K12 | CryptoHives                      | 128KB        |    95,783.8 ns |    270.26 ns |    239.57 ns |    95,737.5 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Keccak-256 | Keccak256_Managed_Scalar**  | **128B**         |       **256.2 ns** |      **2.51 ns** |      **2.22 ns** |       **255.6 ns** |     **112 B** |
| ComputeHash | Keccak-256 | BouncyCastle              | 128B         |       392.3 ns |      2.84 ns |      2.52 ns |       391.5 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F | 128B         |       397.0 ns |      1.08 ns |      0.90 ns |       397.1 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar  | 137B         |       534.6 ns |      6.04 ns |      5.65 ns |       533.3 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle              | 137B         |       709.4 ns |      3.89 ns |      3.64 ns |       709.1 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F | 137B         |       792.7 ns |      2.30 ns |      1.79 ns |       792.6 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar  | 1KB          |     1,784.4 ns |     12.07 ns |     10.70 ns |     1,781.4 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle              | 1KB          |     2,695.2 ns |     40.81 ns |     53.06 ns |     2,687.2 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F | 1KB          |     2,879.8 ns |      4.95 ns |      4.39 ns |     2,878.9 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar  | 1025B        |     1,765.1 ns |      8.04 ns |      7.12 ns |     1,764.4 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle              | 1025B        |     2,674.2 ns |      8.25 ns |      6.89 ns |     2,674.3 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F | 1025B        |     2,865.3 ns |      3.77 ns |      3.52 ns |     2,865.4 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar  | 8KB          |    13,115.0 ns |     38.14 ns |     35.68 ns |    13,108.3 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle              | 8KB          |    19,952.4 ns |     84.11 ns |     70.23 ns |    19,967.3 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F | 8KB          |    21,500.6 ns |     66.64 ns |     59.07 ns |    21,509.0 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar  | 128KB        |   206,111.9 ns |  1,203.53 ns |  1,125.79 ns |   205,886.3 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle              | 128KB        |   314,877.7 ns |    965.91 ns |    806.58 ns |   315,254.7 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F | 128KB        |   338,775.8 ns |  1,057.57 ns |    937.51 ns |   338,853.6 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                 | **128B**         |       **796.9 ns** |      **4.81 ns** |      **4.50 ns** |       **797.3 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                   | **128B**         |     **1,149.9 ns** |     **11.32 ns** |     **10.58 ns** |     **1,150.3 ns** |     **296 B** |
| ComputeHash | KMAC-128 | BouncyCastle                | 128B         |     2,178.4 ns |     12.82 ns |     11.36 ns |     2,175.7 ns |     400 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                 | **137B**         |       **788.5 ns** |      **4.69 ns** |      **4.39 ns** |       **789.1 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                   | **137B**         |     **1,151.9 ns** |      **6.05 ns** |      **5.36 ns** |     **1,150.5 ns** |     **312 B** |
| ComputeHash | KMAC-128 | BouncyCastle                | 137B         |     2,166.5 ns |      9.41 ns |      7.85 ns |     2,163.7 ns |     400 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                 | **1KB**          |     **2,209.8 ns** |     **27.50 ns** |     **25.73 ns** |     **2,201.9 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                   | **1KB**          |     **2,743.2 ns** |     **11.50 ns** |      **9.60 ns** |     **2,744.1 ns** |    **1192 B** |
| ComputeHash | KMAC-128 | BouncyCastle                | 1KB          |     4,215.8 ns |     31.69 ns |     29.64 ns |     4,207.8 ns |     400 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                 | **1025B**        |     **2,195.2 ns** |     **14.60 ns** |     **13.65 ns** |     **2,194.4 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                   | **1025B**        |     **2,759.9 ns** |     **12.86 ns** |     **10.74 ns** |     **2,760.1 ns** |    **1200 B** |
| ComputeHash | KMAC-128 | BouncyCastle                | 1025B        |     4,136.0 ns |     20.08 ns |     18.78 ns |     4,138.5 ns |     400 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                 | **8KB**          |    **11,211.5 ns** |     **25.33 ns** |     **19.78 ns** |    **11,212.8 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                   | **8KB**          |    **14,042.6 ns** |     **87.80 ns** |     **82.13 ns** |    **14,008.7 ns** |    **8360 B** |
| ComputeHash | KMAC-128 | BouncyCastle                | 8KB          |    18,018.0 ns |    107.27 ns |    100.34 ns |    18,001.6 ns |     400 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                 | **128KB**        |   **168,006.1 ns** |    **944.69 ns** |    **788.86 ns** |   **167,836.3 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                   | **128KB**        |   **239,572.7 ns** |  **1,297.25 ns** |  **1,213.45 ns** |   **239,664.2 ns** |  **131263 B** |
| ComputeHash | KMAC-128 | BouncyCastle                | 128KB        |   259,288.8 ns |  1,638.21 ns |  1,367.98 ns |   259,465.7 ns |     400 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                 | **128B**         |       **806.7 ns** |      **6.76 ns** |      **6.32 ns** |       **804.2 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                   | **128B**         |     **1,164.5 ns** |      **6.34 ns** |      **5.93 ns** |     **1,165.6 ns** |     **360 B** |
| ComputeHash | KMAC-256 | BouncyCastle                | 128B         |     2,220.4 ns |     14.58 ns |     12.93 ns |     2,220.6 ns |     464 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                 | **137B**         |     **1,058.0 ns** |      **4.45 ns** |      **3.95 ns** |     **1,058.3 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                   | **137B**         |     **1,407.1 ns** |      **5.20 ns** |      **4.34 ns** |     **1,406.6 ns** |     **376 B** |
| ComputeHash | KMAC-256 | BouncyCastle                | 137B         |     2,469.9 ns |     13.27 ns |     11.76 ns |     2,468.4 ns |     464 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                 | **1KB**          |     **2,354.7 ns** |     **10.01 ns** |      **8.88 ns** |     **2,356.3 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                   | **1KB**          |     **3,030.8 ns** |     **27.68 ns** |     **24.54 ns** |     **3,024.3 ns** |    **1256 B** |
| ComputeHash | KMAC-256 | BouncyCastle                | 1KB          |     4,423.6 ns |     16.87 ns |     14.08 ns |     4,427.7 ns |     464 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                 | **1025B**        |     **2,354.9 ns** |     **12.27 ns** |     **10.88 ns** |     **2,356.4 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                   | **1025B**        |     **3,028.0 ns** |     **15.19 ns** |     **13.46 ns** |     **3,027.9 ns** |    **1264 B** |
| ComputeHash | KMAC-256 | BouncyCastle                | 1025B        |     4,451.8 ns |     22.91 ns |     20.31 ns |     4,453.8 ns |     464 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                 | **8KB**          |    **13,616.0 ns** |     **79.10 ns** |     **73.99 ns** |    **13,596.8 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                   | **8KB**          |    **16,881.5 ns** |     **84.10 ns** |     **70.23 ns** |    **16,891.1 ns** |    **8424 B** |
| ComputeHash | KMAC-256 | BouncyCastle                | 8KB          |    21,708.0 ns |     67.52 ns |     63.16 ns |    21,708.1 ns |     464 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                 | **128KB**        |   **207,120.9 ns** |  **1,153.64 ns** |  **1,079.12 ns** |   **206,746.2 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                   | **128KB**        |   **285,046.9 ns** |    **944.73 ns** |    **737.58 ns** |   **285,256.5 ns** |  **131327 B** |
| ComputeHash | KMAC-256 | BouncyCastle                | 128KB        |   317,501.2 ns |  1,174.35 ns |  1,098.49 ns |   317,630.0 ns |     464 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                        | 128B         |       314.5 ns |      2.11 ns |      1.97 ns |       313.7 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                      | **128B**         |       **384.1 ns** |      **3.19 ns** |      **2.99 ns** |       **384.1 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                     | **128B**         |       **419.0 ns** |      **1.14 ns** |      **1.01 ns** |       **418.8 ns** |      **80 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                        | 137B         |       311.3 ns |      2.19 ns |      1.83 ns |       310.8 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                      | **137B**         |       **384.7 ns** |      **2.09 ns** |      **1.96 ns** |       **383.7 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                     | **137B**         |       **416.3 ns** |      **1.00 ns** |      **0.89 ns** |       **416.3 ns** |      **80 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                        | 1KB          |     1,477.5 ns |      4.29 ns |      3.81 ns |     1,477.8 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                      | **1KB**          |     **1,958.5 ns** |     **11.43 ns** |      **9.54 ns** |     **1,960.4 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                     | **1KB**          |     **2,155.3 ns** |      **8.55 ns** |      **8.00 ns** |     **2,154.1 ns** |      **80 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                        | 1025B        |     1,478.1 ns |      1.81 ns |      1.60 ns |     1,478.0 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                      | **1025B**        |     **1,968.1 ns** |      **9.28 ns** |      **7.75 ns** |     **1,968.2 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                     | **1025B**        |     **2,156.1 ns** |      **4.86 ns** |      **4.55 ns** |     **2,157.2 ns** |      **80 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                        | 8KB          |    10,784.0 ns |     22.67 ns |     18.93 ns |    10,783.9 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                      | **8KB**          |    **14,625.9 ns** |    **117.83 ns** |    **110.22 ns** |    **14,614.2 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                     | **8KB**          |    **16,020.0 ns** |     **68.90 ns** |     **64.45 ns** |    **16,000.0 ns** |      **80 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                        | 128KB        |   170,310.9 ns |    431.56 ns |    403.68 ns |   170,274.0 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                      | **128KB**        |   **232,156.5 ns** |  **1,676.99 ns** |  **1,568.65 ns** |   **231,455.4 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                     | **128KB**        |   **253,660.0 ns** |  **1,221.97 ns** |  **1,143.04 ns** |   **253,928.3 ns** |      **80 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | RIPEMD-160 | BouncyCastle              | 128B         |       721.3 ns |      3.57 ns |      3.16 ns |       720.4 ns |      96 B |
| **ComputeHash | RIPEMD-160 | CryptoHives**               | **128B**         |     **1,062.3 ns** |     **14.03 ns** |     **11.71 ns** |     **1,061.5 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**              | **137B**         |       **711.4 ns** |      **2.44 ns** |      **2.17 ns** |       **710.9 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**               | **137B**         |     **1,061.4 ns** |     **11.31 ns** |      **9.45 ns** |     **1,062.2 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**              | **1KB**          |     **3,782.5 ns** |     **11.94 ns** |     **10.59 ns** |     **3,785.8 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**               | **1KB**          |     **5,827.6 ns** |     **38.14 ns** |     **31.85 ns** |     **5,829.8 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**              | **1025B**        |     **3,838.6 ns** |     **12.82 ns** |     **11.36 ns** |     **3,836.4 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**               | **1025B**        |     **5,787.1 ns** |     **87.95 ns** |     **73.44 ns** |     **5,762.3 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**              | **8KB**          |    **28,261.4 ns** |     **64.48 ns** |     **53.84 ns** |    **28,250.5 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**               | **8KB**          |    **44,744.2 ns** |    **605.52 ns** |    **505.63 ns** |    **44,702.3 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**              | **128KB**        |   **450,539.4 ns** |  **1,273.00 ns** |  **1,128.48 ns** |   **450,852.0 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**               | **128KB**        |   **710,997.2 ns** |  **5,596.76 ns** |  **4,369.58 ns** |   **709,568.6 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                      | **128B**         |       **277.7 ns** |      **4.26 ns** |      **3.99 ns** |       **277.9 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                   | 128B         |       497.5 ns |      3.26 ns |      2.89 ns |       497.0 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                    | **128B**         |       **525.6 ns** |      **4.73 ns** |      **4.19 ns** |       **524.0 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                      | **137B**         |       **277.4 ns** |      **1.14 ns** |      **1.07 ns** |       **277.3 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                   | 137B         |       496.6 ns |      2.36 ns |      2.09 ns |       496.7 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                    | **137B**         |       **521.1 ns** |      **3.25 ns** |      **2.88 ns** |       **520.3 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                      | **1KB**          |     **1,206.2 ns** |      **6.63 ns** |      **5.54 ns** |     **1,204.5 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                   | 1KB          |     2,624.6 ns |     10.53 ns |      9.33 ns |     2,625.1 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                    | **1KB**          |     **2,657.7 ns** |      **8.98 ns** |      **7.96 ns** |     **2,657.8 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                      | **1025B**        |     **1,211.4 ns** |      **6.17 ns** |      **5.15 ns** |     **1,212.3 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                   | 1025B        |     2,607.9 ns |      8.49 ns |      7.53 ns |     2,609.3 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                    | **1025B**        |     **2,666.8 ns** |     **13.66 ns** |     **12.78 ns** |     **2,668.2 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                      | **8KB**          |     **8,659.6 ns** |     **60.56 ns** |     **53.69 ns** |     **8,654.5 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                   | 8KB          |    19,440.6 ns |    128.68 ns |    107.45 ns |    19,433.0 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                    | **8KB**          |    **19,754.0 ns** |     **88.48 ns** |     **82.76 ns** |    **19,727.1 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                      | **128KB**        |   **136,296.6 ns** |    **760.46 ns** |    **674.13 ns** |   **136,112.2 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                   | 128KB        |   310,117.0 ns |  1,675.21 ns |  1,566.99 ns |   310,114.8 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                    | **128KB**        |   **312,612.2 ns** |  **2,696.45 ns** |  **2,251.66 ns** |   **312,431.0 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                 | **128B**         |       **624.0 ns** |      **3.31 ns** |      **2.76 ns** |       **624.0 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                  | **128B**         |       **634.7 ns** |      **1.60 ns** |      **1.34 ns** |       **634.5 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                 | **137B**         |       **627.9 ns** |      **1.59 ns** |      **1.24 ns** |       **628.3 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                  | **137B**         |       **657.2 ns** |      **3.98 ns** |      **3.53 ns** |       **657.6 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                 | **1KB**          |     **3,317.8 ns** |     **12.30 ns** |     **10.90 ns** |     **3,316.3 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                  | **1KB**          |     **3,418.3 ns** |     **11.23 ns** |      **8.77 ns** |     **3,421.7 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                 | **1025B**        |     **3,332.5 ns** |     **20.64 ns** |     **16.12 ns** |     **3,335.1 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                  | **1025B**        |     **3,421.3 ns** |     **16.60 ns** |     **15.52 ns** |     **3,418.9 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                 | **8KB**          |    **24,795.5 ns** |    **121.37 ns** |    **113.53 ns** |    **24,769.9 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                  | **8KB**          |    **25,385.3 ns** |     **51.30 ns** |     **45.48 ns** |    **25,371.3 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                 | **128KB**        |   **392,062.6 ns** |  **1,263.19 ns** |  **1,054.82 ns** |   **391,965.3 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                  | **128KB**        |   **402,386.8 ns** |  **1,034.19 ns** |    **967.38 ns** |   **402,238.8 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                    | **128B**         |       **138.8 ns** |      **0.46 ns** |      **0.36 ns** |       **138.8 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                 | 128B         |       612.2 ns |      3.81 ns |      3.18 ns |       611.3 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                  | **128B**         |       **654.3 ns** |      **3.92 ns** |      **3.47 ns** |       **654.4 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                    | **137B**         |       **139.1 ns** |      **1.51 ns** |      **1.26 ns** |       **138.5 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                 | 137B         |       617.0 ns |      4.28 ns |      4.00 ns |       616.9 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                  | **137B**         |       **657.3 ns** |      **7.20 ns** |      **6.38 ns** |       **656.8 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                    | **1KB**          |       **505.7 ns** |      **2.67 ns** |      **2.50 ns** |       **507.0 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                 | 1KB          |     3,272.0 ns |     13.55 ns |     12.67 ns |     3,273.9 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                  | **1KB**          |     **3,403.9 ns** |     **16.58 ns** |     **15.51 ns** |     **3,401.3 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                    | **1025B**        |       **519.7 ns** |      **1.83 ns** |      **1.72 ns** |       **520.4 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                 | 1025B        |     3,262.9 ns |     11.63 ns |     10.31 ns |     3,257.2 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                  | **1025B**        |     **3,386.4 ns** |     **11.32 ns** |      **8.84 ns** |     **3,383.2 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                    | **8KB**          |     **3,326.7 ns** |      **3.58 ns** |      **3.35 ns** |     **3,327.3 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                 | 8KB          |    24,433.2 ns |     83.02 ns |     73.60 ns |    24,406.4 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                  | **8KB**          |    **25,255.8 ns** |     **79.62 ns** |     **70.58 ns** |    **25,240.3 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                    | **128KB**        |    **51,885.0 ns** |    **125.06 ns** |    **110.86 ns** |    **51,845.3 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                 | 128KB        |   387,337.4 ns |  1,040.00 ns |    868.45 ns |   387,083.5 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                  | **128KB**        |   **400,692.5 ns** |  **1,458.92 ns** |  **1,364.67 ns** |   **400,660.5 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                    | **128B**         |       **415.8 ns** |      **6.86 ns** |      **6.08 ns** |       **414.0 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                 | 128B         |       549.7 ns |      3.62 ns |      3.39 ns |       549.9 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                  | **128B**         |       **581.2 ns** |      **3.30 ns** |      **2.93 ns** |       **581.3 ns** |     **144 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                    | **137B**         |       **412.9 ns** |      **1.80 ns** |      **1.59 ns** |       **412.1 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                 | 137B         |       548.6 ns |      3.30 ns |      3.08 ns |       547.5 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                  | **137B**         |       **580.2 ns** |      **5.95 ns** |      **5.56 ns** |       **578.7 ns** |     **144 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                    | **1KB**          |     **1,548.6 ns** |     **30.24 ns** |     **34.83 ns** |     **1,537.8 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                 | 1KB          |     2,272.3 ns |      7.32 ns |      6.11 ns |     2,271.9 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                  | **1KB**          |     **2,286.5 ns** |      **9.33 ns** |      **8.73 ns** |     **2,285.7 ns** |     **144 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                    | **1025B**        |     **1,514.4 ns** |      **5.81 ns** |      **5.43 ns** |     **1,514.3 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                 | 1025B        |     2,257.8 ns |      7.09 ns |      5.92 ns |     2,257.5 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                  | **1025B**        |     **2,288.4 ns** |      **8.61 ns** |      **8.06 ns** |     **2,285.5 ns** |     **144 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                    | **8KB**          |    **10,358.5 ns** |     **22.01 ns** |     **20.59 ns** |    **10,356.7 ns** |     **144 B** |
| **ComputeHash | SHA-384 | CryptoHives**                  | **8KB**          |    **15,843.7 ns** |     **89.34 ns** |     **83.57 ns** |    **15,859.9 ns** |     **144 B** |
| **ComputeHash | SHA-384 | BouncyCastle**                 | **8KB**          |    **15,909.2 ns** |     **55.34 ns** |     **46.21 ns** |    **15,919.8 ns** |     **144 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA-384 | OS Native                    | 128KB        |   162,469.1 ns |    591.91 ns |    524.71 ns |   162,333.0 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                  | **128KB**        |   **249,144.8 ns** |  **1,330.93 ns** |  **1,244.95 ns** |   **249,394.0 ns** |     **144 B** |
| **ComputeHash | SHA-384 | BouncyCastle**                 | **128KB**        |   **250,192.6 ns** |  **1,265.20 ns** |    **987.79 ns** |   **250,369.8 ns** |     **144 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA-512 | OS Native                    | 128B         |       397.8 ns |      1.79 ns |      1.59 ns |       397.7 ns |     176 B |
| ComputeHash | SHA-512 | BouncyCastle                 | 128B         |       542.7 ns |      1.64 ns |      1.45 ns |       542.7 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                  | **128B**         |       **607.1 ns** |      **3.41 ns** |      **3.19 ns** |       **606.4 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                    | **137B**         |       **403.7 ns** |      **3.04 ns** |      **2.70 ns** |       **403.0 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                 | 137B         |       553.9 ns |      4.90 ns |      4.34 ns |       554.0 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                  | **137B**         |       **608.7 ns** |      **3.70 ns** |      **3.28 ns** |       **608.6 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                    | **1KB**          |     **1,522.4 ns** |      **9.17 ns** |      **8.13 ns** |     **1,521.1 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                 | 1KB          |     2,280.7 ns |     10.83 ns |      9.05 ns |     2,280.6 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                  | **1KB**          |     **2,417.2 ns** |      **9.05 ns** |      **7.56 ns** |     **2,415.1 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                    | **1025B**        |     **1,532.3 ns** |     **11.45 ns** |     **10.15 ns** |     **1,536.4 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                 | 1025B        |     2,278.6 ns |      8.60 ns |      8.04 ns |     2,279.1 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                  | **1025B**        |     **2,416.1 ns** |      **9.07 ns** |      **7.58 ns** |     **2,415.5 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                    | **8KB**          |    **10,481.1 ns** |     **62.84 ns** |     **55.70 ns** |    **10,463.3 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                 | 8KB          |    16,087.0 ns |    113.59 ns |    106.25 ns |    16,075.9 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                  | **8KB**          |    **16,822.5 ns** |    **140.94 ns** |    **131.84 ns** |    **16,790.6 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                    | **128KB**        |   **164,353.2 ns** |    **970.84 ns** |    **810.69 ns** |   **164,237.4 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                 | 128KB        |   252,808.7 ns |  1,444.60 ns |  1,351.28 ns |   252,711.3 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                  | **128KB**        |   **264,531.7 ns** |  **3,216.95 ns** |  **2,686.30 ns** |   **263,738.1 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**             | **128B**         |       **559.2 ns** |      **4.47 ns** |      **4.18 ns** |       **559.0 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**              | **128B**         |       **580.9 ns** |      **3.30 ns** |      **2.93 ns** |       **580.6 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**             | **137B**         |       **564.3 ns** |      **2.95 ns** |      **2.62 ns** |       **564.5 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**              | **137B**         |       **583.3 ns** |      **3.40 ns** |      **3.01 ns** |       **582.8 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**             | **1KB**          |     **2,291.2 ns** |     **17.25 ns** |     **15.29 ns** |     **2,285.6 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**              | **1KB**          |     **2,307.9 ns** |     **14.42 ns** |     **12.78 ns** |     **2,305.8 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**             | **1025B**        |     **2,279.9 ns** |     **10.00 ns** |      **8.87 ns** |     **2,280.9 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**              | **1025B**        |     **2,315.6 ns** |     **25.42 ns** |     **22.53 ns** |     **2,310.7 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA-512/224 | CryptoHives              | 8KB          |    15,943.3 ns |     72.11 ns |     63.93 ns |    15,932.4 ns |     112 B |
| **ComputeHash | SHA-512/224 | BouncyCastle**             | **8KB**          |    **15,981.4 ns** |     **84.02 ns** |     **70.16 ns** |    **15,983.4 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | CryptoHives**              | **128KB**        |   **250,540.5 ns** |  **1,639.63 ns** |  **1,453.49 ns** |   **250,398.0 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | BouncyCastle**             | **128KB**        |   **252,647.1 ns** |  **1,876.46 ns** |  **1,663.44 ns** |   **252,275.0 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA-512/256 | BouncyCastle             | 128B         |       562.3 ns |      4.93 ns |      4.37 ns |       561.0 ns |     112 B |
| **ComputeHash | SHA-512/256 | CryptoHives**              | **128B**         |       **577.6 ns** |      **2.15 ns** |      **1.91 ns** |       **577.9 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**             | **137B**         |       **565.4 ns** |      **2.91 ns** |      **2.58 ns** |       **566.0 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**              | **137B**         |       **576.5 ns** |      **2.60 ns** |      **2.31 ns** |       **576.7 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**             | **1KB**          |     **2,290.0 ns** |     **15.22 ns** |     **13.49 ns** |     **2,290.0 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**              | **1KB**          |     **2,295.7 ns** |     **20.80 ns** |     **18.44 ns** |     **2,292.6 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**             | **1025B**        |     **2,283.6 ns** |      **9.80 ns** |      **9.17 ns** |     **2,284.3 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**              | **1025B**        |     **2,292.4 ns** |     **14.00 ns** |     **13.09 ns** |     **2,288.1 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA-512/256 | CryptoHives              | 8KB          |    15,952.4 ns |     98.22 ns |     91.87 ns |    15,957.5 ns |     112 B |
| **ComputeHash | SHA-512/256 | BouncyCastle**             | **8KB**          |    **16,041.8 ns** |    **140.99 ns** |    **131.88 ns** |    **16,000.1 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512/256 | CryptoHives**              | **128KB**        |   **250,198.7 ns** |  **1,623.48 ns** |  **1,439.17 ns** |   **249,676.8 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | BouncyCastle**             | **128KB**        |   **251,687.7 ns** |  **1,834.86 ns** |  **1,716.33 ns** |   **251,004.5 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar     | 128B         |       259.3 ns |      1.73 ns |      1.53 ns |       259.4 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                | 128B         |       390.5 ns |      1.24 ns |      1.16 ns |       390.6 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F    | 128B         |       403.9 ns |      3.05 ns |      2.55 ns |       402.9 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar     | 137B         |       257.4 ns |      2.22 ns |      1.97 ns |       257.3 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                | 137B         |       390.2 ns |      2.20 ns |      1.95 ns |       389.9 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F    | 137B         |       400.9 ns |      0.88 ns |      0.78 ns |       400.7 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar     | 1KB          |     1,797.9 ns |     10.50 ns |      9.30 ns |     1,796.0 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                | 1KB          |     2,676.2 ns |      8.29 ns |      7.35 ns |     2,672.8 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F    | 1KB          |     2,903.6 ns |      3.52 ns |      2.75 ns |     2,902.5 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar     | 1025B        |     1,834.7 ns |      8.78 ns |      8.21 ns |     1,836.1 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                | 1025B        |     2,665.6 ns |     10.38 ns |      8.67 ns |     2,665.1 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F    | 1025B        |     2,902.7 ns |      6.83 ns |      6.05 ns |     2,900.8 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar     | 8KB          |    12,223.5 ns |     33.15 ns |     31.01 ns |    12,226.3 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                | 8KB          |    18,696.5 ns |     65.75 ns |     51.34 ns |    18,710.8 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F    | 8KB          |    20,059.1 ns |     40.55 ns |     37.93 ns |    20,044.7 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar     | 128KB        |   194,896.8 ns |  1,087.43 ns |    963.97 ns |   194,678.6 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                | 128KB        |   296,717.5 ns |  1,170.06 ns |    977.05 ns |   296,670.4 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F    | 128KB        |   319,684.9 ns |    529.56 ns |    495.35 ns |   319,615.1 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar     | 128B         |       267.1 ns |      1.88 ns |      1.76 ns |       266.8 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                   | 128B         |       331.5 ns |      1.13 ns |      1.06 ns |       331.4 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                | 128B         |       389.7 ns |      0.78 ns |      0.69 ns |       389.5 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F    | 128B         |       400.6 ns |      0.58 ns |      0.51 ns |       400.5 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar     | 137B         |       527.9 ns |      2.38 ns |      1.86 ns |       527.8 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                   | 137B         |       577.9 ns |      3.70 ns |      3.28 ns |       577.3 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                | 137B         |       702.5 ns |      1.45 ns |      1.14 ns |       702.6 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F    | 137B         |       804.4 ns |      1.11 ns |      0.99 ns |       804.2 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar     | 1KB          |     1,770.7 ns |     10.83 ns |      9.60 ns |     1,766.8 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                   | 1KB          |     2,100.4 ns |     11.92 ns |     10.57 ns |     2,100.5 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                | 1KB          |     2,670.5 ns |     15.36 ns |     12.82 ns |     2,669.4 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F    | 1KB          |     2,871.0 ns |      5.49 ns |      4.59 ns |     2,869.5 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar     | 1025B        |     1,766.2 ns |      3.73 ns |      3.49 ns |     1,765.8 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                   | 1025B        |     2,111.9 ns |     10.74 ns |      9.52 ns |     2,112.4 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                | 1025B        |     2,663.2 ns |      8.00 ns |      7.48 ns |     2,664.6 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F    | 1025B        |     2,868.7 ns |      3.74 ns |      3.31 ns |     2,868.3 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar     | 8KB          |    13,067.1 ns |     58.68 ns |     54.89 ns |    13,046.1 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                   | 8KB          |    15,481.3 ns |    121.39 ns |    107.61 ns |    15,495.8 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                | 8KB          |    20,532.6 ns |    406.53 ns |    499.26 ns |    20,296.1 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F    | 8KB          |    21,462.3 ns |     38.65 ns |     36.16 ns |    21,462.9 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar     | 128KB        |   209,124.5 ns |  4,099.68 ns |  5,330.75 ns |   206,720.1 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                   | 128KB        |   247,253.6 ns |  4,892.81 ns |  4,576.74 ns |   245,636.0 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                | 128KB        |   317,592.8 ns |  3,104.28 ns |  2,903.74 ns |   317,955.6 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F    | 128KB        |   340,935.0 ns |  2,533.28 ns |  2,369.63 ns |   339,993.9 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar     | 128B         |       529.5 ns |      9.95 ns |     23.25 ns |       523.1 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                   | 128B         |       570.3 ns |      4.47 ns |      3.96 ns |       569.9 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                | 128B         |       713.9 ns |      5.60 ns |      5.23 ns |       713.1 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F    | 128B         |       773.1 ns |      2.30 ns |      2.15 ns |       773.0 ns |     144 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar     | 137B         |       504.1 ns |      6.13 ns |      5.44 ns |       503.6 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                   | 137B         |       582.6 ns |      7.38 ns |      6.54 ns |       580.5 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                | 137B         |       710.3 ns |      5.13 ns |      4.54 ns |       709.4 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F    | 137B         |       784.2 ns |      6.79 ns |      6.02 ns |       783.3 ns |     144 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar     | 1KB          |     2,220.3 ns |     35.57 ns |     33.27 ns |     2,213.4 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                   | 1KB          |     2,597.0 ns |     14.29 ns |     11.94 ns |     2,598.3 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                | 1KB          |     3,321.5 ns |     21.54 ns |     20.15 ns |     3,316.7 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F    | 1KB          |     3,650.9 ns |     40.90 ns |     38.26 ns |     3,636.7 ns |     144 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar     | 1025B        |     2,180.7 ns |     25.12 ns |     23.49 ns |     2,179.8 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                   | 1025B        |     2,599.4 ns |     26.77 ns |     25.04 ns |     2,598.3 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                | 1025B        |     3,334.5 ns |     22.64 ns |     18.91 ns |     3,327.2 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F    | 1025B        |     3,561.5 ns |      9.10 ns |      8.07 ns |     3,563.5 ns |     144 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar     | 8KB          |    17,027.0 ns |    226.84 ns |    201.09 ns |    16,987.9 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                   | 8KB          |    19,915.0 ns |    194.78 ns |    182.20 ns |    19,900.7 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                | 8KB          |    25,976.1 ns |    288.48 ns |    269.85 ns |    25,827.8 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F    | 8KB          |    27,750.6 ns |    139.04 ns |    130.06 ns |    27,755.4 ns |     144 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar     | 128KB        |   278,849.7 ns |  5,545.79 ns |  7,211.10 ns |   279,286.7 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                   | 128KB        |   316,956.2 ns |  2,341.27 ns |  2,075.48 ns |   316,793.1 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                | 128KB        |   413,684.0 ns |  2,809.99 ns |  2,490.98 ns |   413,279.5 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F    | 128KB        |   440,961.1 ns |  1,797.02 ns |  1,680.93 ns |   440,559.3 ns |     144 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar     | 128B         |       480.5 ns |      5.11 ns |      4.53 ns |       479.4 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                   | 128B         |       582.0 ns |      5.39 ns |      4.50 ns |       581.6 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                | 128B         |       713.4 ns |      3.08 ns |      2.73 ns |       714.3 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F    | 128B         |       765.3 ns |      9.30 ns |      8.70 ns |       762.4 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar     | 137B         |       469.3 ns |      4.89 ns |      4.58 ns |       468.2 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                   | 137B         |       579.1 ns |      6.49 ns |      6.08 ns |       576.3 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                | 137B         |       710.1 ns |      3.53 ns |      3.30 ns |       710.8 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F    | 137B         |       755.7 ns |      3.31 ns |      3.09 ns |       756.2 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar     | 1KB          |     3,231.1 ns |     12.93 ns |     10.80 ns |     3,232.3 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                   | 1KB          |     3,858.9 ns |     11.95 ns |     10.59 ns |     3,860.7 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                | 1KB          |     4,933.7 ns |     20.28 ns |     18.97 ns |     4,938.6 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F    | 1KB          |     5,379.3 ns |     32.13 ns |     30.06 ns |     5,389.2 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar     | 1025B        |     3,245.6 ns |     10.97 ns |      9.16 ns |     3,243.0 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                   | 1025B        |     3,837.7 ns |     17.44 ns |     13.62 ns |     3,837.5 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                | 1025B        |     4,952.7 ns |     21.49 ns |     20.10 ns |     4,953.8 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F    | 1025B        |     5,368.1 ns |     33.46 ns |     31.30 ns |     5,351.1 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar     | 8KB          |    24,287.7 ns |    138.90 ns |    129.93 ns |    24,230.0 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                   | 8KB          |    28,641.7 ns |    116.52 ns |     97.30 ns |    28,632.7 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                | 8KB          |    37,342.9 ns |    154.38 ns |    136.86 ns |    37,304.3 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F    | 8KB          |    40,541.5 ns |    247.28 ns |    231.30 ns |    40,558.8 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar     | 128KB        |   385,552.7 ns |  2,289.94 ns |  1,787.83 ns |   385,410.5 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                   | 128KB        |   459,399.7 ns |  1,681.59 ns |  1,572.96 ns |   458,861.0 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                | 128KB        |   597,526.0 ns |  2,201.35 ns |  2,059.14 ns |   598,179.8 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F    | 128KB        |   643,030.3 ns |  4,535.80 ns |  4,242.79 ns |   640,548.9 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE128 | CryptoHives**                 | **128B**         |       **302.0 ns** |      **2.39 ns** |      **2.24 ns** |       **301.2 ns** |     **112 B** |
| **ComputeHash | SHAKE128 | BouncyCastle**                | **128B**         |       **393.3 ns** |      **1.82 ns** |      **1.70 ns** |       **392.8 ns** |     **112 B** |
| ComputeHash | SHAKE128 | OS Native                   | 128B         |       424.4 ns |      1.86 ns |      1.56 ns |       424.0 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE128 | CryptoHives**                 | **137B**         |       **297.6 ns** |      **1.70 ns** |      **1.59 ns** |       **297.3 ns** |     **112 B** |
| **ComputeHash | SHAKE128 | BouncyCastle**                | **137B**         |       **393.8 ns** |      **2.55 ns** |      **2.39 ns** |       **393.0 ns** |     **112 B** |
| ComputeHash | SHAKE128 | OS Native                   | 137B         |       415.3 ns |      1.97 ns |      1.65 ns |       416.0 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE128 | CryptoHives**                 | **1KB**          |     **1,651.6 ns** |      **7.74 ns** |      **7.24 ns** |     **1,650.7 ns** |     **112 B** |
| **ComputeHash | SHAKE128 | OS Native**                   | **1KB**          |     **1,980.0 ns** |     **26.78 ns** |     **23.74 ns** |     **1,976.7 ns** |     **112 B** |
| ComputeHash | SHAKE128 | BouncyCastle                | 1KB          |     2,395.3 ns |     12.41 ns |     11.00 ns |     2,395.1 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE128 | CryptoHives**                 | **1025B**        |     **1,640.7 ns** |      **6.86 ns** |      **6.08 ns** |     **1,640.6 ns** |     **112 B** |
| **ComputeHash | SHAKE128 | OS Native**                   | **1025B**        |     **2,005.8 ns** |     **39.92 ns** |     **53.29 ns** |     **1,991.7 ns** |     **112 B** |
| ComputeHash | SHAKE128 | BouncyCastle                | 1025B        |     2,403.2 ns |     22.57 ns |     20.01 ns |     2,399.1 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE128 | CryptoHives**                 | **8KB**          |    **10,723.7 ns** |     **51.33 ns** |     **42.87 ns** |    **10,730.9 ns** |     **112 B** |
| **ComputeHash | SHAKE128 | OS Native**                   | **8KB**          |    **12,812.5 ns** |     **80.94 ns** |     **75.71 ns** |    **12,800.6 ns** |     **112 B** |
| ComputeHash | SHAKE128 | BouncyCastle                | 8KB          |    16,328.7 ns |    130.12 ns |    121.72 ns |    16,336.8 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE128 | CryptoHives**                 | **128KB**        |   **168,589.4 ns** |    **723.19 ns** |    **641.09 ns** |   **168,702.2 ns** |     **112 B** |
| **ComputeHash | SHAKE128 | OS Native**                   | **128KB**        |   **199,856.8 ns** |    **807.10 ns** |    **673.97 ns** |   **199,656.8 ns** |     **112 B** |
| ComputeHash | SHAKE128 | BouncyCastle                | 128KB        |   265,578.5 ns |  2,470.18 ns |  2,189.75 ns |   265,836.3 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE256 | CryptoHives**                 | **128B**         |       **331.4 ns** |      **2.32 ns** |      **1.81 ns** |       **331.4 ns** |     **176 B** |
| **ComputeHash | SHAKE256 | OS Native**                   | **128B**         |       **417.0 ns** |      **3.10 ns** |      **2.90 ns** |       **416.5 ns** |     **176 B** |
| ComputeHash | SHAKE256 | BouncyCastle                | 128B         |       422.5 ns |      7.43 ns |     13.02 ns |       419.0 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE256 | CryptoHives**                 | **137B**         |       **588.3 ns** |      **6.49 ns** |      **5.42 ns** |       **589.0 ns** |     **176 B** |
| **ComputeHash | SHAKE256 | OS Native**                   | **137B**         |       **692.6 ns** |     **12.18 ns** |     **14.96 ns** |       **690.9 ns** |     **176 B** |
| ComputeHash | SHAKE256 | BouncyCastle                | 137B         |       719.7 ns |      4.95 ns |      4.63 ns |       717.5 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE256 | CryptoHives**                 | **1KB**          |     **1,861.8 ns** |     **19.15 ns** |     **16.98 ns** |     **1,856.5 ns** |     **176 B** |
| **ComputeHash | SHAKE256 | OS Native**                   | **1KB**          |     **2,219.5 ns** |     **12.33 ns** |     **10.93 ns** |     **2,215.9 ns** |     **176 B** |
| ComputeHash | SHAKE256 | BouncyCastle                | 1KB          |     2,702.1 ns |     20.95 ns |     18.57 ns |     2,705.5 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE256 | CryptoHives**                 | **1025B**        |     **1,835.4 ns** |     **18.31 ns** |     **15.29 ns** |     **1,833.4 ns** |     **176 B** |
| **ComputeHash | SHAKE256 | OS Native**                   | **1025B**        |     **2,213.2 ns** |     **11.03 ns** |      **9.78 ns** |     **2,214.5 ns** |     **176 B** |
| ComputeHash | SHAKE256 | BouncyCastle                | 1025B        |     2,713.9 ns |     28.67 ns |     26.82 ns |     2,724.9 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE256 | CryptoHives**                 | **8KB**          |    **13,169.4 ns** |     **37.94 ns** |     **31.68 ns** |    **13,168.1 ns** |     **176 B** |
| **ComputeHash | SHAKE256 | OS Native**                   | **8KB**          |    **15,737.7 ns** |     **69.64 ns** |     **61.74 ns** |    **15,731.5 ns** |     **176 B** |
| ComputeHash | SHAKE256 | BouncyCastle                | 8KB          |    20,195.3 ns |    120.08 ns |    100.27 ns |    20,178.5 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE256 | CryptoHives**                 | **128KB**        |   **210,854.4 ns** |  **3,760.81 ns** |  **4,756.23 ns** |   **210,083.9 ns** |     **176 B** |
| **ComputeHash | SHAKE256 | OS Native**                   | **128KB**        |   **244,484.3 ns** |    **895.94 ns** |    **794.23 ns** |   **244,358.5 ns** |     **176 B** |
| ComputeHash | SHAKE256 | BouncyCastle                | 128KB        |   317,076.9 ns |  1,641.24 ns |  1,454.91 ns |   317,253.5 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SM3 | BouncyCastle                     | 128B         |       883.0 ns |     12.94 ns |     11.47 ns |       876.8 ns |     112 B |
| **ComputeHash | SM3 | CryptoHives**                      | **128B**         |     **1,044.0 ns** |     **11.55 ns** |     **10.80 ns** |     **1,047.6 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                     | **137B**         |       **891.3 ns** |      **3.61 ns** |      **3.20 ns** |       **890.7 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                      | **137B**         |     **1,029.5 ns** |      **5.35 ns** |      **4.74 ns** |     **1,029.5 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                     | **1KB**          |     **4,772.5 ns** |     **53.08 ns** |     **47.06 ns** |     **4,753.7 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                      | **1KB**          |     **5,613.1 ns** |     **35.71 ns** |     **31.65 ns** |     **5,622.3 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                     | **1025B**        |     **4,765.1 ns** |     **52.60 ns** |     **49.20 ns** |     **4,751.1 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                      | **1025B**        |     **5,733.1 ns** |     **92.09 ns** |     **86.14 ns** |     **5,751.0 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                     | **8KB**          |    **36,208.3 ns** |    **203.50 ns** |    **180.40 ns** |    **36,200.4 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                      | **8KB**          |    **42,137.5 ns** |    **217.12 ns** |    **192.47 ns** |    **42,169.1 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                     | **128KB**        |   **580,370.0 ns** |  **9,985.82 ns** |  **8,852.17 ns** |   **577,199.8 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                      | **128KB**        |   **669,123.1 ns** |  **3,698.56 ns** |  **3,459.63 ns** |   **669,001.5 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | Streebog-256 | CryptoHives             | 128B         |     2,628.8 ns |     18.79 ns |     17.57 ns |     2,630.0 ns |     112 B |
| **ComputeHash | Streebog-256 | OpenGost**                | **128B**         |     **3,780.6 ns** |     **32.21 ns** |     **26.90 ns** |     **3,778.4 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle            | 128B         |     4,717.4 ns |     27.40 ns |     21.39 ns |     4,713.9 ns |     200 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**             | **137B**         |     **2,510.9 ns** |      **7.89 ns** |      **7.38 ns** |     **2,513.5 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                | **137B**         |     **3,766.4 ns** |     **34.09 ns** |     **31.89 ns** |     **3,762.3 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle            | 137B         |     4,742.1 ns |     64.15 ns |     60.01 ns |     4,722.7 ns |     200 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**             | **1KB**          |     **9,532.1 ns** |     **46.01 ns** |     **40.79 ns** |     **9,517.6 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                | **1KB**          |    **14,188.9 ns** |    **283.32 ns** |    **290.94 ns** |    **14,134.7 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle            | 1KB          |    17,968.2 ns |    226.09 ns |    211.49 ns |    17,895.8 ns |     200 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**             | **1025B**        |    **10,385.1 ns** |     **57.04 ns** |     **53.36 ns** |    **10,403.1 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                | **1025B**        |    **13,770.0 ns** |     **84.22 ns** |     **78.78 ns** |    **13,763.6 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle            | 1025B        |    18,297.5 ns |    342.93 ns |    304.00 ns |    18,304.3 ns |     200 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**             | **8KB**          |    **66,598.7 ns** |    **329.63 ns** |    **308.33 ns** |    **66,707.5 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                | **8KB**          |    **94,218.2 ns** |    **718.72 ns** |    **637.13 ns** |    **93,920.7 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle            | 8KB          |   122,073.1 ns |    481.38 ns |    426.73 ns |   122,080.9 ns |     200 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**             | **128KB**        | **1,045,317.8 ns** | **10,102.33 ns** |  **9,449.73 ns** | **1,042,692.6 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                | **128KB**        | **1,471,934.2 ns** | **11,179.80 ns** |  **9,910.60 ns** | **1,465,690.4 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle            | 128KB        | 1,903,703.5 ns |  8,158.57 ns |  7,232.36 ns | 1,902,888.0 ns |     200 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**             | **128B**         |     **2,587.3 ns** |     **34.89 ns** |     **32.64 ns** |     **2,573.2 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                | **128B**         |     **4,326.7 ns** |     **67.89 ns** |     **63.51 ns** |     **4,320.9 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle            | 128B         |     4,656.0 ns |     18.40 ns |     15.37 ns |     4,655.4 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**             | **137B**         |     **2,541.9 ns** |     **25.52 ns** |     **23.87 ns** |     **2,530.8 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                | **137B**         |     **3,684.9 ns** |     **71.38 ns** |     **79.34 ns** |     **3,662.8 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle            | 137B         |     4,970.2 ns |     14.92 ns |     11.65 ns |     4,972.7 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**             | **1KB**          |     **9,446.0 ns** |     **37.23 ns** |     **33.00 ns** |     **9,447.9 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                | **1KB**          |    **13,716.2 ns** |     **69.92 ns** |     **61.98 ns** |    **13,720.5 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle            | 1KB          |    17,517.2 ns |     88.33 ns |     78.30 ns |    17,536.6 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**             | **1025B**        |     **9,504.1 ns** |     **63.87 ns** |     **56.62 ns** |     **9,498.4 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                | **1025B**        |    **14,194.3 ns** |    **159.38 ns** |    **133.09 ns** |    **14,178.6 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle            | 1025B        |    17,648.7 ns |     46.75 ns |     41.44 ns |    17,643.2 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**             | **8KB**          |    **67,937.4 ns** |    **362.06 ns** |    **338.67 ns** |    **67,895.8 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                | **8KB**          |    **97,238.6 ns** |  **1,898.63 ns** |  **2,031.51 ns** |    **97,257.0 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle            | 8KB          |   125,823.1 ns |  2,499.10 ns |  2,337.66 ns |   124,445.1 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**             | **128KB**        | **1,089,890.4 ns** | **19,913.41 ns** | **17,652.72 ns** | **1,083,887.4 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                | **128KB**        | **1,489,623.9 ns** | **17,051.77 ns** | **15,950.24 ns** | **1,487,781.6 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle            | 128KB        | 1,910,667.3 ns | 11,885.62 ns | 11,117.82 ns | 1,909,349.4 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                | **128B**         |     **1,534.7 ns** |     **29.94 ns** |     **32.03 ns** |     **1,529.3 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**               | **128B**         |     **5,525.9 ns** |     **47.69 ns** |     **37.23 ns** |     **5,523.6 ns** |     **232 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                | **137B**         |     **1,503.6 ns** |     **10.02 ns** |      **8.89 ns** |     **1,499.9 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**               | **137B**         |     **5,526.4 ns** |     **82.67 ns** |     **77.33 ns** |     **5,500.3 ns** |     **232 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                | **1KB**          |     **8,411.3 ns** |     **53.86 ns** |     **44.98 ns** |     **8,416.3 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**               | **1KB**          |    **33,652.4 ns** |    **128.43 ns** |    **113.85 ns** |    **33,685.4 ns** |     **232 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                | **1025B**        |     **8,384.5 ns** |     **57.14 ns** |     **50.66 ns** |     **8,374.3 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**               | **1025B**        |    **33,821.6 ns** |    **185.73 ns** |    **164.65 ns** |    **33,775.7 ns** |     **232 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                | **8KB**          |    **63,284.9 ns** |    **437.56 ns** |    **387.89 ns** |    **63,189.4 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**               | **8KB**          |   **257,850.9 ns** |  **1,465.34 ns** |  **1,370.68 ns** |   **257,888.2 ns** |     **232 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                | **128KB**        | **1,001,320.5 ns** |  **8,186.06 ns** |  **7,256.72 ns** |   **999,650.8 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**               | **128KB**        | **4,174,813.1 ns** | **60,322.58 ns** | **53,474.40 ns** | **4,167,757.8 ns** |     **232 B** |
