```

BenchmarkDotNet v0.15.8, macOS Tahoe 26.6.2 (25G83) [Darwin 25.6.0]
Apple M4, 1 CPU, 10 logical and 10 physical cores
.NET SDK 10.0.400
  [Host]    : .NET 10.0.11 (10.0.11, 10.0.1126.37416), Arm64 RyuJIT armv8.0-a
  .NET 10.0 : .NET 10.0.11 (10.0.11, 10.0.1126.37416), Arm64 RyuJIT armv8.0-a

Method=TryComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                         | TestDataSize | Mean             | Error         | StdDev        | Median           | Allocated |
|---------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|-----------------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 4B           |         53.06 ns |      0.171 ns |      0.160 ns |         53.08 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 4B           |         54.24 ns |      0.143 ns |      0.120 ns |         54.24 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 4B           |         55.44 ns |      0.258 ns |      0.241 ns |         55.37 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 4B           |         55.54 ns |      0.235 ns |      0.220 ns |         55.53 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 4B           |         65.59 ns |      0.356 ns |      0.316 ns |         65.59 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 4B           |         65.71 ns |      0.156 ns |      0.130 ns |         65.69 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 4B           |        387.31 ns |      1.335 ns |      1.249 ns |        387.27 ns |         - |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 100B         |        100.03 ns |      0.192 ns |      0.180 ns |        100.03 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 100B         |        108.80 ns |      0.404 ns |      0.378 ns |        108.90 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 100B         |        117.21 ns |      0.356 ns |      0.333 ns |        117.19 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 100B         |        117.35 ns |      0.409 ns |      0.383 ns |        117.39 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 100B         |        118.13 ns |      0.434 ns |      0.406 ns |        118.10 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 100B         |        118.20 ns |      0.436 ns |      0.407 ns |        118.22 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 100B         |        771.04 ns |      2.939 ns |      2.749 ns |        771.35 ns |         - |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 128B         |        101.06 ns |      0.028 ns |      0.027 ns |        101.06 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 128B         |        110.22 ns |      0.017 ns |      0.014 ns |        110.22 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 128B         |        115.23 ns |      0.075 ns |      0.066 ns |        115.24 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 128B         |        115.24 ns |      0.075 ns |      0.066 ns |        115.26 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 128B         |        116.20 ns |      0.395 ns |      0.370 ns |        116.16 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 128B         |        116.34 ns |      0.301 ns |      0.282 ns |        116.35 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 128B         |        767.38 ns |      2.496 ns |      2.335 ns |        767.73 ns |         - |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 137B         |        149.81 ns |      0.308 ns |      0.288 ns |        149.85 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 137B         |        167.51 ns |      0.507 ns |      0.474 ns |        167.43 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 137B         |        179.12 ns |      0.340 ns |      0.302 ns |        179.07 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 137B         |        179.74 ns |      0.511 ns |      0.478 ns |        179.55 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 137B         |        180.16 ns |      0.481 ns |      0.450 ns |        180.04 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 137B         |        180.34 ns |      0.502 ns |      0.445 ns |        180.20 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 137B         |      1,165.02 ns |      2.855 ns |      2.671 ns |      1,164.49 ns |         - |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1000B        |        868.33 ns |      4.363 ns |      4.081 ns |        870.42 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1000B        |        910.15 ns |      6.641 ns |      5.887 ns |        908.12 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1000B        |        910.24 ns |     10.349 ns |      9.174 ns |        909.25 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 1000B        |        921.58 ns |      2.524 ns |      2.361 ns |        921.52 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1000B        |        952.51 ns |      2.363 ns |      2.210 ns |        953.08 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1000B        |        962.76 ns |      7.881 ns |      7.372 ns |        959.69 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1000B        |      5,890.25 ns |     94.118 ns |    254.454 ns |      5,793.73 ns |         - |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1KB          |        787.34 ns |      4.721 ns |      4.416 ns |        784.83 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1KB          |        895.90 ns |      3.068 ns |      2.719 ns |        896.93 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1KB          |        902.37 ns |      0.566 ns |      0.442 ns |        902.54 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 1KB          |        926.62 ns |     11.089 ns |      9.830 ns |        925.11 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1KB          |        955.49 ns |      1.192 ns |      0.996 ns |        955.86 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1KB          |        956.07 ns |      2.920 ns |      2.589 ns |        955.26 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1KB          |      5,685.96 ns |     57.887 ns |     51.316 ns |      5,695.41 ns |         - |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1025B        |        887.05 ns |      1.150 ns |      0.898 ns |        887.07 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1025B        |      1,014.14 ns |      0.418 ns |      0.349 ns |      1,014.22 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1025B        |      1,033.39 ns |      0.304 ns |      0.285 ns |      1,033.36 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 1025B        |      1,033.68 ns |      0.374 ns |      0.350 ns |      1,033.65 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1025B        |      1,072.35 ns |      0.905 ns |      0.756 ns |      1,072.29 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1025B        |      1,075.69 ns |      1.511 ns |      1.340 ns |      1,075.11 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1025B        |      6,787.11 ns |    128.072 ns |    119.799 ns |      6,813.39 ns |      56 B |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 2KB          |      1,616.27 ns |      0.794 ns |      0.743 ns |      1,616.05 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 2KB          |      1,887.34 ns |     12.908 ns |     12.074 ns |      1,896.08 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 2KB          |      1,892.53 ns |      2.406 ns |      2.133 ns |      1,892.92 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 2KB          |      1,893.48 ns |      6.260 ns |      4.887 ns |      1,892.06 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 2KB          |      1,969.80 ns |      1.582 ns |      1.321 ns |      1,969.62 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 2KB          |      2,000.56 ns |     11.732 ns |     10.974 ns |      2,005.30 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 2KB          |     12,050.60 ns |    128.592 ns |    113.993 ns |     12,087.76 ns |      56 B |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 4KB          |      1,711.67 ns |     33.398 ns |     53.932 ns |      1,681.43 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 4KB          |      1,977.32 ns |     11.980 ns |     11.206 ns |      1,974.38 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 4KB          |      1,988.64 ns |     12.817 ns |     10.703 ns |      1,987.01 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 4KB          |      2,081.41 ns |     40.651 ns |     38.025 ns |      2,092.63 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 4KB          |      2,112.85 ns |     28.930 ns |     25.646 ns |      2,124.48 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 4KB          |      3,814.97 ns |     32.155 ns |     28.505 ns |      3,801.79 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 4KB          |     24,490.84 ns |    229.489 ns |    214.664 ns |     24,575.34 ns |     168 B |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 6KB          |      3,210.61 ns |     20.815 ns |     18.452 ns |      3,209.78 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 6KB          |      3,856.27 ns |     41.514 ns |     36.801 ns |      3,856.74 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 6KB          |      3,933.41 ns |     41.051 ns |     38.399 ns |      3,913.48 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 6KB          |      3,952.68 ns |     78.046 ns |     92.909 ns |      3,931.85 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 6KB          |      4,035.28 ns |     58.062 ns |     54.312 ns |      4,005.75 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 6KB          |      5,749.94 ns |     66.136 ns |     58.627 ns |      5,717.47 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 6KB          |     36,168.67 ns |    713.717 ns |    632.692 ns |     35,840.28 ns |     280 B |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 8KB          |      3,426.10 ns |     52.554 ns |     49.159 ns |      3,418.35 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 8KB          |      3,827.90 ns |     15.502 ns |     14.501 ns |      3,826.44 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 8KB          |      3,950.77 ns |     72.158 ns |     67.497 ns |      3,968.29 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 8KB          |      4,020.66 ns |     29.125 ns |     25.818 ns |      4,008.52 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 8KB          |      4,087.87 ns |     56.757 ns |     53.091 ns |      4,089.45 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 8KB          |      7,752.55 ns |     75.163 ns |     66.630 ns |      7,742.30 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 8KB          |     47,849.36 ns |    173.151 ns |    153.493 ns |     47,808.38 ns |     392 B |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 9216B        |      4,106.33 ns |     25.279 ns |     23.646 ns |      4,108.31 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 9216B        |      4,865.48 ns |     30.666 ns |     28.685 ns |      4,871.44 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 9216B        |      4,899.57 ns |     38.027 ns |     33.710 ns |      4,903.88 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 9216B        |      4,945.83 ns |     65.732 ns |     61.486 ns |      4,947.82 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 9216B        |      4,945.89 ns |     31.161 ns |     29.148 ns |      4,954.28 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 9216B        |      8,620.56 ns |     36.024 ns |     30.081 ns |      8,605.58 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 9216B        |     54,481.42 ns |    178.921 ns |    167.363 ns |     54,483.35 ns |     448 B |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 10000B       |      4,560.33 ns |     31.909 ns |     29.848 ns |      4,539.52 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 10000B       |      5,353.46 ns |     35.216 ns |     32.941 ns |      5,352.40 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 10000B       |      5,792.54 ns |    115.692 ns |    228.364 ns |      5,683.35 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 10000B       |      5,970.02 ns |     87.610 ns |     81.951 ns |      5,984.44 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 10000B       |      6,082.03 ns |    114.163 ns |     95.331 ns |      6,110.66 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 10000B       |      9,390.27 ns |     10.788 ns |      9.008 ns |      9,388.96 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 10000B       |     57,737.07 ns |    325.247 ns |    304.236 ns |     57,736.95 ns |     504 B |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 10240B       |      5,053.17 ns |     55.188 ns |     51.623 ns |      5,047.92 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 10240B       |      5,925.03 ns |     43.170 ns |     40.381 ns |      5,921.35 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 10240B       |      5,974.90 ns |     32.784 ns |     30.667 ns |      5,970.40 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 10240B       |      5,980.93 ns |     44.304 ns |     41.442 ns |      5,970.07 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 10240B       |      6,326.94 ns |     78.908 ns |     69.950 ns |      6,344.97 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 10240B       |      9,564.07 ns |      1.661 ns |      1.387 ns |      9,563.93 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 10240B       |     59,640.54 ns |    339.869 ns |    283.806 ns |     59,672.44 ns |     504 B |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 11264B       |      5,679.21 ns |     27.517 ns |     21.484 ns |      5,673.82 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 11264B       |      6,088.14 ns |     32.956 ns |     30.828 ns |      6,087.37 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 11264B       |      6,703.85 ns |     19.236 ns |     17.993 ns |      6,700.18 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 11264B       |      6,853.43 ns |     70.775 ns |     69.510 ns |      6,842.53 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 11264B       |      7,193.13 ns |     16.991 ns |     15.893 ns |      7,194.03 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 11264B       |     10,512.10 ns |      4.403 ns |      3.903 ns |     10,511.24 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 11264B       |     66,775.86 ns |    154.892 ns |    144.886 ns |     66,771.87 ns |     560 B |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 12288B       |      4,956.65 ns |     24.315 ns |     22.744 ns |      4,953.47 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 12288B       |      5,711.46 ns |    104.682 ns |     97.920 ns |      5,685.70 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 12288B       |      6,045.23 ns |     40.424 ns |     37.812 ns |      6,045.09 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 12288B       |      6,189.74 ns |     19.293 ns |     17.102 ns |      6,197.68 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 12288B       |      6,264.30 ns |    110.110 ns |    102.997 ns |      6,316.57 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 12288B       |     11,622.57 ns |     26.094 ns |     21.790 ns |     11,632.30 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 12288B       |     73,752.55 ns |    704.966 ns |    659.426 ns |     73,732.17 ns |     616 B |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 15360B       |      7,428.57 ns |    144.410 ns |    187.774 ns |      7,305.71 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 15360B       |      8,122.72 ns |    161.055 ns |    269.086 ns |      7,980.97 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 15360B       |      8,452.06 ns |     42.614 ns |     39.861 ns |      8,449.17 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 15360B       |      9,188.31 ns |     52.146 ns |     48.778 ns |      9,195.39 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 15360B       |      9,250.75 ns |     54.484 ns |     50.964 ns |      9,236.84 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 15360B       |     14,363.62 ns |      7.936 ns |      6.627 ns |     14,362.60 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 15360B       |     89,279.88 ns |  1,026.378 ns |    909.857 ns |     89,073.36 ns |     784 B |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 64KB         |     26,558.19 ns |     89.417 ns |     79.266 ns |     26,563.79 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 64KB         |     30,894.13 ns |    151.230 ns |    134.062 ns |     30,861.66 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 64KB         |     33,315.83 ns |    300.339 ns |    280.937 ns |     33,348.17 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 64KB         |     33,429.29 ns |    325.268 ns |    271.613 ns |     33,284.51 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 64KB         |     34,675.17 ns |    689.874 ns |  1,094.213 ns |     34,155.77 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 64KB         |     62,435.54 ns |     23.071 ns |     20.452 ns |     62,438.03 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 64KB         |    391,907.19 ns |  4,910.064 ns |  4,352.644 ns |    390,839.32 ns |    3528 B |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 100000B      |     18,832.97 ns |     41.219 ns |     36.539 ns |     18,848.84 ns |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 100000B      |     40,775.71 ns |    270.967 ns |    240.205 ns |     40,749.01 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 100000B      |     47,198.96 ns |    272.624 ns |    255.013 ns |     47,136.37 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 100000B      |     49,678.46 ns |    660.376 ns |    585.406 ns |     49,411.38 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 100000B      |     52,783.44 ns |    169.365 ns |    158.424 ns |     52,807.30 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 100000B      |     94,963.97 ns |    571.583 ns |    534.660 ns |     95,236.22 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 100000B      |    586,142.10 ns |  2,174.751 ns |  2,034.263 ns |    585,574.99 ns |    5432 B |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 128KB        |     20,045.51 ns |    350.930 ns |    556.613 ns |     19,796.69 ns |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 128KB        |     53,868.97 ns |    241.894 ns |    214.433 ns |     53,898.47 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 128KB        |     62,277.92 ns |    182.535 ns |    170.744 ns |     62,273.59 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 128KB        |     64,709.49 ns |  1,261.242 ns |  2,072.257 ns |     63,589.15 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 128KB        |     68,060.64 ns |     20.837 ns |     18.472 ns |     68,057.57 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 128KB        |    123,198.96 ns |     87.309 ns |     77.397 ns |    123,194.87 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 128KB        |    779,707.27 ns |  1,385.036 ns |  1,156.568 ns |    779,756.79 ns |    7112 B |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 256KB        |     37,723.69 ns |    616.793 ns |    802.005 ns |     37,486.46 ns |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 256KB        |    106,927.70 ns |  2,075.318 ns |  2,624.612 ns |    106,152.06 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 256KB        |    123,367.76 ns |    566.613 ns |    530.010 ns |    123,265.27 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 256KB        |    134,167.76 ns |  1,010.033 ns |    944.785 ns |    134,103.92 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 256KB        |    134,350.20 ns |  2,100.901 ns |  1,862.394 ns |    135,011.30 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 256KB        |    251,684.32 ns |    262.188 ns |    232.422 ns |    251,663.89 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 256KB        |  1,577,202.16 ns |  6,314.188 ns |  5,906.295 ns |  1,576,355.47 ns |   14280 B |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 512KB        |     55,027.05 ns |    631.976 ns |    591.150 ns |     55,333.28 ns |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 512KB        |    214,910.03 ns |    835.224 ns |    781.269 ns |    214,966.86 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 512KB        |    247,564.06 ns |  1,361.001 ns |  1,273.081 ns |    247,649.35 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 512KB        |    255,737.02 ns |  1,440.108 ns |  1,276.618 ns |    255,658.17 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 512KB        |    273,343.48 ns |    738.291 ns |    690.598 ns |    273,542.58 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 512KB        |    500,705.06 ns |  2,054.627 ns |  1,921.899 ns |    500,938.52 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 512KB        |  3,142,145.51 ns |  9,154.559 ns |  8,115.278 ns |  3,143,437.83 ns |   28616 B |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1MB          |     98,713.55 ns |  1,776.984 ns |  1,662.192 ns |     98,921.90 ns |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1MB          |    414,174.67 ns |  1,923.162 ns |  1,798.927 ns |    413,828.17 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1MB          |    490,128.79 ns |  1,427.525 ns |  1,335.308 ns |    489,845.58 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 1MB          |    496,565.73 ns |  2,394.948 ns |  2,240.236 ns |    496,643.39 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1MB          |    529,365.14 ns |    759.794 ns |    673.537 ns |    529,238.22 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1MB          |    954,360.24 ns |  2,227.732 ns |  2,083.822 ns |    954,395.92 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1MB          |  6,013,061.56 ns | 18,004.546 ns | 16,841.464 ns |  6,016,436.52 ns |   54656 B |
|                                                     |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 10MB         |    811,827.29 ns |  7,962.244 ns |  7,058.322 ns |    811,532.23 ns |     144 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 10MB         |  4,266,436.71 ns | 12,810.124 ns | 11,982.598 ns |  4,264,292.31 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 10MB         |  4,821,305.67 ns | 10,285.507 ns |  9,621.070 ns |  4,821,862.30 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon          | 10MB         |  5,072,215.14 ns |  4,328.152 ns |  3,379.136 ns |  5,071,164.38 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 10MB         |  5,224,324.00 ns | 14,238.914 ns | 13,319.089 ns |  5,230,166.98 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 10MB         |  9,643,478.29 ns | 32,492.507 ns | 30,393.512 ns |  9,628,093.08 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 10MB         | 60,845,685.87 ns | 68,956.570 ns | 61,128.203 ns | 60,826,319.50 ns |  546840 B |
